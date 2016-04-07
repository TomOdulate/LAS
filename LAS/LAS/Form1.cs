using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Application;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Data.SqlServerCe;
using System.Windows.Forms.DataVisualization.Charting;
using Tao.LAS.Properties;
using Tao.LAS.Utils;

namespace Tao.LAS
{
    public partial class Form1 : Form
    {
        #region IE sound hack...

        const int Feature = FeatureDisableNavigationSounds;       
        private const int FeatureDisableNavigationSounds = 21;
        private const int SetFeatureOnProcess = 0x00000002;
        
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return:MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(int featureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags,bool fEnable);

        #endregion
        
        private readonly string _activityUrl;
        private bool _stopDataRequest;
        private bool _loadingStartPage;
        private readonly SqlCeConnection _cn; 
        private SqlCeCommand _select;
        private SqlCeResultSet _resultSet;
        private SqlCeResultSet _resultSetTargets;
        private SqlCeResultSet _resultSetErrors;
        private int _historyDepth = 100;
        private const int MaxHistoryDepth = 650000;
        private int _currentDepth;
        private long _startTime;
        private long _endTime;
        
        public Form1()
        {
            InitializeComponent();
            _activityUrl = Settings.Default.strActivityUrl;
            _cn = new SqlCeConnection(Settings.Default.LASDBConnectionString);
        }

        private void Reset()
        {
            // Clear the database
            var m = new Maintenance(_cn);

            m.ClearTables();

            // Clear the username & action combo boxes
            GetAvailableUsernames();

            // Clear the datagrid
            GetTab1Data();
            
            // Clear any chart data & hide it.
            chart1.Hide();
            chart1.Series.Clear();

            //Now update the status bar
            UpdateStatusStrip("Ready", false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentDoubleClick += OpenLinkFromGrid;
            dgTargets.CellContentDoubleClick += OpenLinkFromGrid;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            trackBar1.Maximum = MaxHistoryDepth;
            numericUpDown1.Maximum = MaxHistoryDepth;
            numericUpDown1.Value = _historyDepth;
            dataGridView1.AutoGenerateColumns = true;
            SetupReportDropdowns();
            GetStartPage();
            Reset();
            
            #if (!DEBUG)
                tabControl1.TabPages.RemoveByKey("tabDbFunctions");
                tabControl1.TabPages.RemoveByKey("tabParseTest");
            #endif
        }
        
        private void UpdateStatusStrip(string status = "Ready",bool statusOnly = true)
        {
            if (!statusOnly)
            {
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();

                // Get the total number of records
                var cmd = _cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Settings.Default.sqlGetTotalRecordCount;
                double sampleSize = int.Parse(cmd.ExecuteScalar().ToString());
                lblSampleSize.Text = sampleSize.ToString(CultureInfo.InvariantCulture);

                // Get the total number of errors
                cmd = _cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Settings.Default.sqlGetTotalErrorCount;
                double totalErrors = int.Parse(cmd.ExecuteScalar().ToString());
                lblTotalErrors.Text = totalErrors.ToString();

                // Calculate accuracy
                double acc = 100 - (totalErrors/sampleSize*100);
                lblAccuracy.Text = Math.Truncate(acc) + Resources.Form1_UpdateStatusStrip_Percent;

                // Calculate max history depth
                cmd = _cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Settings.Default.sqlGetMaxHistoryDepthRawData;
                var s = cmd.ExecuteScalar();
                lblHistoryDepth.Text = PageParser.ParseDataAge(s as string);
            }

            // Reset the progress bar
            if (String.CompareOrdinal(status, "Ready") == 0)
            {
                tsProgressBar.Value = 0;
                toolStripUpTimeLabel.Text = String.Empty;
            }

            // Update the current status
            lblStatus.Text = status;
            statusStrip1.Refresh();
        }
        
        #region Data retrieval tab

        private void GetStartPage()
        {
            _loadingStartPage = true;
            string version;

            if (ApplicationDeployment.IsNetworkDeployed)
                version = "Version: " + ApplicationDeployment.CurrentDeployment.CurrentVersion;
            else
                version = "Build Version: " + Application.ProductVersion;

            webBrowser1.DocumentText = Settings.Default.htmlStartPage.Replace("version 1.0", version );
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Record the start time.
            _startTime = DateTime.Now.Ticks;
            
            // Disable / enable buttons
            EnableButtons(true);

            // Enable auto update of the Reports tab
            tmrReports.Enabled = true;
            
            // Get the data.
            RetrieveData();

            // Disable auto update of the Reports tab
            tmrReports_Tick(null,null);  // Get a last update in 'cos screen data could be (timer interval) old.
            tmrReports.Enabled = false;
            
            // Disable / enable buttons
            EnableButtons(false);

            // Record the end time.
            _endTime = DateTime.Now.Ticks;
            
            // Calc & show the total time taken
            var t = new TimeSpan(_endTime - _startTime);
            var sb = new StringBuilder();
            if(t.Days > 0) sb.AppendFormat("{0} days", t.Days);
            if(t.Hours > 0) sb.AppendFormat(" {0} hours", t.Hours);
            if (t.Minutes > 0) sb.AppendFormat(" {0} mins", t.Minutes);
            sb.AppendFormat(" {0} sec{1}",t.Seconds, t.Seconds==1?"":"s");
            MessageBox.Show(Resources.Total_time_taken + sb,Resources.analysis_complete,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void RetrieveData()
        {
            // Silence the browser object ;)
            CoInternetSetFeatureEnabled(Feature, SetFeatureOnProcess, true);
            
            // Clear existing data.
            Reset();

            _stopDataRequest = false;
            int lastDepth = 0;
            
            tsProgressBar.Maximum = _historyDepth;
            UpdateStatusStrip("Downloading");

            while (_currentDepth <= _historyDepth & !_stopDataRequest)
            {
                var ts = Maintenance.CalcUpTime(new DateTime(_startTime));
                toolStripUpTimeLabel.Text = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);

                if (lastDepth == _currentDepth)
                {
                    Application.DoEvents();
                    continue;
                }
                lastDepth = _currentDepth;
                
                // Update the progress bar
                tsProgressBar.Value = _currentDepth;

                var ub = new UriBuilder(_activityUrl + _currentDepth);
                TargetUrl.Text = ub.Uri.ToString();
                
                while(webBrowser1.IsBusy)
                {
                    Application.DoEvents();
                }
                webBrowser1.Navigate(ub.Uri);
            }
            
            
            GetStartPage();
            // Turn browser navigation sounds back on
            CoInternetSetFeatureEnabled(Feature, SetFeatureOnProcess, false);
            UpdateStatusStrip("Ready",false);
            GetAvailableUsernames();
        }

        public int SaveData(List<DataLine> dataLines)
        {
            var rowsAffected = 0;
            try
            {
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();

                foreach (DataLine dataLine in dataLines)
                {
                    var tmpRawData = dataLine.ContentRaw;
                    var insertCommand = new SqlCeCommand(
                        "INSERT INTO UserActivity  (RawData, PageId, Username, Action, Target, TargetLink) VALUES (N'"
                            + HttpUtility.HtmlEncode(dataLine.ContentRaw) + "',"
                            + "N'" + dataLine.PageID + "',"
                            + "N'" + dataLine.UserName + "',"
                            + "N'" + dataLine.Action + "',"
                            + "N'" + dataLine.Target  + "',"
                            + "N'" + HttpUtility.UrlDecode(dataLine.TargetLink).Replace("amp;","") + "'"
                            + ")"
                        , _cn);

                    try
                    {
                        rowsAffected += insertCommand.ExecuteNonQuery();
                        Application.DoEvents();
                    }
                    catch (SqlCeException)
                    {
                        var sb = new StringBuilder();
                        sb.AppendFormat("Page id='{0}', User ='{1}', Action='{2}', Target='{3}', TargetLink='{4}'",
                                        dataLine.PageID, dataLine.UserName, dataLine.Action, dataLine.Target,
                                        HttpUtility.UrlEncode(dataLine.TargetLink));


                        Logger.LogError("Error saving DataLine object: " + sb + " :" + tmpRawData);
                        continue;
                    }
                }
            }
            finally
            {

            }
            
            return rowsAffected;
        }

        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (_loadingStartPage) return;
            if (webBrowser1.Document != null)
            {
                if (webBrowser1.Document.Body != null)
                {
                    string[] splitStrings = {
                                        "<UL class=pagenav>",
                                        "<DIV class=section_title>Recent activity results</DIV>"
                                    };
                
                    var split = webBrowser1.Document.Body.InnerHtml.Split(splitStrings,StringSplitOptions.RemoveEmptyEntries);
                    webBrowser1.Document.Body.InnerHtml = split[0];
                }
            }
        }
        
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Increment our current history depth
            _currentDepth++;

            // Store the results.
            PageData pd;
            if (webBrowser1.Document != null)
            {
                if (webBrowser1.Document.Body != null)
                {
                    // If we haven't hit the last page.
                    if (!webBrowser1.Document.Body.ToString().Contains(Settings.Default.strNoMorePages))
                    {
                        if (!_loadingStartPage)
                        {
                            // Extrapolate the page data
                            pd = new PageData { PageID = long.Parse(HttpUtility.ParseQueryString(e.Url.ToString())["page"]) ,ContentRaw = webBrowser1.Document.Body.InnerHtml};

                            // Parse the page data
                            var dataLines = PageParser.ParsePage(pd);
                            
                            // Save the parsed data
                            SaveData(dataLines);
                            
                            // Update the history depth label
                            lblHistoryDepth.Text = pd.Age();
                            statusStrip1.Refresh();
                        }
                    }
                    else
                    {
                        // We've hit the last page.
                        _stopDataRequest = true;
                        _historyDepth = _currentDepth;
                    }
                }
            }
            

            if (_loadingStartPage)
            {
                _loadingStartPage = false;
                tsProgressBar.Value = 0;
            }

            if( _stopDataRequest )
            {
                webBrowser1.Stop();
                _stopDataRequest = false;
                GetStartPage();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = int.Parse(numericUpDown1.Value.ToString());
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            txtHistoryDepth.Text = trackBar1.Value.ToString();
            _historyDepth = trackBar1.Value;
            numericUpDown1.Value = trackBar1.Value;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stopDataRequest = true;
            _historyDepth = _currentDepth;
            EnableButtons(false);
        }

        private void EnableButtons(bool busy)
        {
            btnGo.Enabled = !busy;
            btnStop.Enabled = busy;
            tpTargets.Enabled = !busy;
            tpUserActions.Enabled = !busy;
        }

        #endregion


        #region UserAnalysis tab

        private void GetAvailableUsernames()
        {
            var selectUsernames = new SqlCeCommand("SELECT Username FROM UserActivity GROUP BY Username", _cn);
            var selectionActions = new SqlCeCommand("SELECT Action FROM UserActivity GROUP BY Action", _cn);

            cboUserName.DisplayMember = "Name";
            cboUserName.ValueMember = "Value";
            cboUserActions.DisplayMember = "Action";
            cboUserActions.ValueMember = "Value";
            cboUserActions.Update();

            cboUserName.Items.Clear();
            cboUserActions.Items.Clear();
            
            if (_cn.State != ConnectionState.Open)
                _cn.Open();

            var userNames = selectUsernames.ExecuteResultSet(ResultSetOptions.Scrollable);

            UpdateStatusStrip("Parsing Users");
            tsProgressBar.Maximum = int.Parse(lblSampleSize.Text);
            tsProgressBar.Value = 0;
            while (userNames.Read())
            {
                cboUserName.Items.Add(new UserName(userNames["Username"].ToString()));
                txtTargetName.AutoCompleteCustomSource.Add(userNames["Username"].ToString());
                txtRptUserName.AutoCompleteCustomSource.Add(userNames["Username"].ToString());
                if (tsProgressBar.Value < tsProgressBar.Maximum) tsProgressBar.Value++;
            }

            var userActions = selectionActions.ExecuteReader();
            UpdateStatusStrip("Actions search");
            tsProgressBar.Value = 0;
            while (userActions.Read())
            {
                cboUserActions.Items.Add(new UserActions(userActions["Action"].ToString()));
                if (tsProgressBar.Value < tsProgressBar.Maximum) tsProgressBar.Value++;
            }

            cboUserActions.Items.Add( new UserActions("All") );
            
            if (cboUserName.Items.Count != 1)
                lblUsernames.Text = cboUserName.Items.Count + Resources.Form1_cboUserName_Usernames;
            else
                lblUsernames.Text = cboUserName.Items.Count + Resources.Form1_cboUserName_Username;
            
            if(cboUserName.Items.Count>0)
            {
                cboUserName.SelectedItem = cboUserName.Items[0];
                cboUserActions.SelectedItem = cboUserActions.Items[0];
            }
            UpdateStatusStrip();
        }

        private void cboUserActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkUAAutoUpdate.Checked) 
                GetTab1Data();
        }

        private void cboUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkUAAutoUpdate.Checked)
                GetTab1Data();
        }

        private void GetTab1Data()
        {
            try
            {
                if (cboUserName.SelectedItem == null | cboUserActions.SelectedItem == null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    lblRecordCount.Text = Resources.Form1_GetTab1Data__0_Records_Found_;
                    return;
                }
                
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();

                var username = ((UserName) cboUserName.SelectedItem).Name;
                //UserActions action = new UserActions(cboUserActions.SelectedText);
                var action = ((UserActions)cboUserActions.SelectedItem).Action;
                var query = "";
                if (System.String.Compare(action, "All", System.StringComparison.Ordinal) == 0)
                {
                    query = "SELECT Username, Action, Target, TargetLink FROM UserActivity Where Username = '" + username + "'";                    
                }
                else
                {
                    query = "SELECT Username, Action, Target, TargetLink FROM UserActivity Where Username = '" + username + "' and Action ='" + action + "'";                    
                }

                
                _select = new SqlCeCommand(query, _cn) {CommandType = CommandType.Text};
                _resultSet = _select.ExecuteResultSet(ResultSetOptions.Scrollable);
                dataGridView1.DataSource = _resultSet;
                dataGridView1.DataError += dataGridView1_DataError;
                dataGridView1.ReadOnly = true;
                dataGridView1.Update();
                lblRecordCount.Text = dataGridView1.RowCount + Resources.Form1_GetTab1Data__Records_Found_;

                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            
        }

        void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["Target"].Value =
                HttpUtility.HtmlDecode(dataGridView1.Rows[e.RowIndex].Cells["Target"].Value.ToString());

            dataGridView1.Rows[e.RowIndex].Cells["TargetLink"].Value =
                HttpUtility.HtmlDecode(dataGridView1.Rows[e.RowIndex].Cells["TargetLink"].Value.ToString());
        }

        static void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Logger.LogError(e.Exception.Message);
        }
        
        private static void OpenLinkFromGrid(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null) return;
            if (string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString())) return;
            
            var target = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            System.Diagnostics.Process.Start(target);
        }
        
        private void btnUAFind_Click(object sender, EventArgs e)
        {
            GetTab1Data();
        }

        #endregion


        #region Top 10 tab

        private void GetBarChartData(string queryName, int maxResults = 10, string itemWidth = "350")
        {
            SqlCeCommand sqlSelectCmd = _cn.CreateCommand();
            sqlSelectCmd.CommandType = CommandType.Text;

            var xAxisLabel = string.Empty;

            switch (queryName)
            {
                case "TopVotersQuery": 
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopVotersQuery;
                    chart1.Titles[0].Text = "Top 10 comment voters";
                    xAxisLabel = "Total comment votes";
                    break;
                case "TopDownVotersQuery":
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopDownVotersQuery;
                    chart1.Titles[0].Text = "Top 10 comment down voters";
                    xAxisLabel = "Total negative votes given";
                    break;
                case "TopDownVoteRecipientsQuery":
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopDownVoteRecipientsQuery;
                    chart1.Titles[0].Text = "Top 10 comment down voter recipients";
                    xAxisLabel = "Total negative votes recieved";
                    break;
                case "TopUpVotersQuery":
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopUpVotersQuery;
                    chart1.Titles[0].Text = "Top 10 comment up voters";
                    xAxisLabel = "Total positive votes given";
                    break;
                case "TopUpVoteRecipientsQuery":
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopUpVoteRecipientsQuery;
                    chart1.Titles[0].Text = "Top 10 comment up vote recipients";
                    xAxisLabel = "Total positive votes revieved";
                    break;
                case "TopCommentorsQuery":
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopCommentorsQuery;
                    chart1.Titles[0].Text = "Top 10 commentors";
                    xAxisLabel = "Total comments made";
                    break;
                case "TopUploadersQuery":
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopUploadersQuery;
                    chart1.Titles[0].Text = "Top 10 uploaders";
                    xAxisLabel = "Total uploads made";
                    break;
                default:
                    sqlSelectCmd.CommandText = Settings.Default.sqlTopDownVotersQuery;
                    break;
            }

            try
            {
                
                if (_cn.State != ConnectionState.Open) _cn.Open();
                var ceResultSet = sqlSelectCmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                Series s;
                
                chart1.Series.Clear();
                chart1.ResetAutoValues();
                
                var count = 0;
                while (ceResultSet.Read() & count < maxResults)
                {
                    s = new Series(ceResultSet["Username"].ToString());
                    s.Points.Add(int.Parse(ceResultSet[1].ToString()));
                    s.IsValueShownAsLabel = true;
                    s.AxisLabel = xAxisLabel;
                    s["PixelPointWidth"] = itemWidth;
                    chart1.Series.Add(s);
                    count++;
                }
                chart1.Update();
                if (chart1.Series.Count > 0)
                {
                    chart1.Show();
                    lblNoData.Hide();
                }
                else
                {
                    chart1.Hide();
                    lblNoData.Show();
                }
            }
            finally
            {
                
            }
        }

        private void SetupReportDropdowns()
        {
            // Create a List to store our KeyValuePairs
            var data = new List<KeyValuePair<string, string>>();

            // Add data to the List
            data.Add(new KeyValuePair<string, string>("TopVotersQuery", "Top 10 comment voters"));
            data.Add(new KeyValuePair<string, string>("TopDownVotersQuery", "Top 10 comment down voters"));
            data.Add(new KeyValuePair<string, string>("TopDownVoteRecipientsQuery", "Top 10 down vote recipients"));
            data.Add(new KeyValuePair<string, string>("TopUpVotersQuery", "Top 10 comment up voters"));
            data.Add(new KeyValuePair<string, string>("TopUpVoteRecipientsQuery", "Top 10 up vote recipients"));
            data.Add(new KeyValuePair<string, string>("TopCommentorsQuery", "Top 10 commentors"));
            data.Add(new KeyValuePair<string, string>("TopUploadersQuery", "Top 10 uploaders"));
            
            // Bind the combobox
            cboTop10ReportName.DataSource = new BindingSource(data, null);
            cboTop10ReportName.DisplayMember = "Value";
            cboTop10ReportName.ValueMember = "Key";
        }

        private void cboTop10ReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBarChartData(cboTop10ReportName.SelectedValue.ToString());
        }

        #endregion


        #region Maintenance Tab

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var m = new Maintenance(_cn);
            m.CompactDb();
            UpdateStatusStrip("Ready", false);
        }

        private void btnViewErrors_Click(object sender, EventArgs e)
        {
            if (_cn.State != ConnectionState.Open)
                _cn.Open();

            var cmd = _cn.CreateCommand();
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "ErrorLog";
            _resultSetErrors = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);

            while (_resultSetErrors.Read())
            {
                textBox1.AppendText("\r\n" + _resultSetErrors[1] + " - " + HttpUtility.HtmlDecode(_resultSetErrors[2].ToString()));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Upgrade();
        }

        private void Upgrade()
        {
            // Upgrade the database
            var m = new Maintenance(_cn);
            m.UpgragdeDb();
        }

        #endregion       


        #region TargetsTab

        private void button1_Click(object sender, EventArgs e)
        {
            GetTargetData();
        }

        private void GetTargetData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTargetName.Text))
                {
                    dgTargets.DataSource = null;
                    dgTargets.Rows.Clear();
                    lblTargetCount.Text = Resources.Form1_GetTab1Data__0_Records_Found_;
                    return;
                }

                if (_cn.State != ConnectionState.Open)
                    _cn.Open();

                var target = txtTargetName.Text;
                var query = Settings.Default.sqlGetActivityByTarget.Replace("[TARGET]",target);
                var selectTargets = new SqlCeCommand(query, _cn) { CommandType = CommandType.Text };

                _resultSetTargets = selectTargets.ExecuteResultSet(ResultSetOptions.Scrollable);
                dgTargets.DataSource = _resultSetTargets;
                dgTargets.ReadOnly = true;
                dgTargets.Update();
                lblTargetCount.Text = dgTargets.RowCount + Resources.Form1_GetTab1Data__Records_Found_;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }

        

        #endregion


        #region ParseTest tab
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParseInput.Text))
                return;
            
            string[] splitStrings = {
                                        "<UL class=pagenav>",
                                        "<DIV class=section_title>Recent activity results</DIV>"
                                    };
            string[] split = txtParseInput.Text.Split(splitStrings,StringSplitOptions.RemoveEmptyEntries);
            var inputText = split[0];
            
            var pd = new PageData {ContentRaw = inputText};
            List<DataLine> data =  PageParser.ParsePage(pd);
            var sb = new StringBuilder();
            txtParseOutput.Clear();

            sb.AppendLine("Page Age:" + pd.Age());

            foreach (var dataLine in data)
            {
                sb.AppendLine(dataLine.UserName);
                sb.AppendLine(dataLine.Age());
                sb.AppendLine(dataLine.Action);
                sb.AppendLine(dataLine.PageID.ToString());
                sb.AppendLine(dataLine.TargetLink);
                sb.AppendLine(dataLine.Target);
                sb.AppendLine("---");
                sb.AppendLine("");
                txtParseOutput.Text = sb.ToString();
            }
            UpdateStatusStrip();
        }

        #endregion


        #region Reports

        private void btnRptDownVotes_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.VotedDown, chkRptShowDetail.Checked);
        }

        private void btnRptUpVotes_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.VotedUp, chkRptShowDetail.Checked);
        }

        private void btnRptItemVotes_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.VotedOnItem, chkRptShowDetail.Checked);
        }

        private void btnSubscriptions_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.Subscribed, chkRptShowDetail.Checked);
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.Unsubscribed, chkRptShowDetail.Checked);
        }

        private void btnRptComments_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.AddedComment, chkRptShowDetail.Checked);
        }
        
        private void btnFavoured_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.Favoured, chkRptShowDetail.Checked);
        }

        private void btnFullReport_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text = BuildFullReport(txtRptUserName.Text, chkRptShowDetail.Checked);
        }
        
        private void bntRptUploads_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text += BuildReport(txtRptUserName.Text, UserAction.Uploaded, chkRptShowDetail.Checked);
        }

        private void btnRtpClear_Click(object sender, EventArgs e)
        {
            txtRptOutput.Clear();
        }

        private void btnRptHeader_Click(object sender, EventArgs e)
        {
            txtRptOutput.Text = BuildRptHeader() + txtRptOutput.Text;
        }

        private string BuildRptHeader()
        {
            var startTime = new DateTime(_startTime);
            var s = "LiveLeak Activity Spy report on '" + txtRptUserName.Text + "' \r\n";
            s += "Valid between " + startTime.ToShortDateString() + " " + startTime.ToShortTimeString() + " & " + lblHistoryDepth.Text;
            s += "\r\nData sample accuracy " + lblAccuracy.Text;
            s += "\r\n---------------------------------------------";
            s += "\r\n";
            return s;
        }

        private void btnRptCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtRptOutput.Text);
        }
        
        private string BuildFullReport(string user, bool showDetail)
        {
            var s = new StringBuilder();
            s.AppendLine(BuildRptHeader());
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.VotedOnItem, chkRptShowDetail.Checked));
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.VotedUp, chkRptShowDetail.Checked));
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.VotedDown, chkRptShowDetail.Checked));
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.AddedComment, chkRptShowDetail.Checked));
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.Favoured, chkRptShowDetail.Checked));
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.Subscribed, chkRptShowDetail.Checked));
            s.AppendLine(BuildReport(txtRptUserName.Text, UserAction.Unsubscribed, chkRptShowDetail.Checked));
            return s.ToString();
        }
        
        private string BuildReport(string user, UserAction userAction, bool detail = false)
        {
            // Check connection
            if (_cn.State != ConnectionState.Open)
                _cn.Open();

            // Build the query
            var cmd = _cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = GetRptQueryText(userAction,user);
            
            // Get the results
            var results = cmd.ExecuteReader();
            var total = 0;
            var sb = new StringBuilder();
            var title = string.Empty;

            // Build the report
            switch (userAction)
            {
                case UserAction.AddedComment:
                    while (results.Read())
                    {
                        total += int.Parse(results["Count"].ToString());
                        if (!detail) continue;
                        sb.Append(results["Count"].ToString());
                        sb.Append(" ");
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                        sb.Append(" ");
                        sb.AppendLine(results["TargetLink"].ToString());
                    }
                    title = "Comments";
                    break;
                
                case UserAction.Subscribed:
                    while (results.Read())
                    {
                        total++;
                        if (!detail) continue; 
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                    }

                    title = "Subscribed";
                    break;
                
                case UserAction.Unsubscribed:
                    while (results.Read())
                    {
                        total++;
                        if (!detail) continue;
                        sb.AppendLine(results["Target"].ToString());
                    }
                    title = "Unsubscribed";
                    break;
                
                case UserAction.VotedOnItem:
                    while (results.Read())
                    {
                        total ++;
                        if (!detail) continue;
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                    }
                    title = "Total item votes";
                    break;
                
                case UserAction.VotedUp:
                    while (results.Read())
                    {
                        total += int.Parse(results["Count"].ToString());
                        if (!detail) continue;
                        sb.Append(results["Count"].ToString());
                        sb.Append(" ");
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                    }
                    title = "Total up votes";
                    break;
                
                case UserAction.VotedDown:
                    while(results.Read())
                    {
                        total += int.Parse(results["Count"].ToString());
                        if (!detail) continue;
                        sb.Append(results["Count"].ToString());
                        sb.Append(" ");
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                    }
                    title = "Total down votes";
                    break;
                
                case UserAction.Favoured:
                    while (results.Read())
                    {
                        total++;
                        if (!detail) continue;
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                    }
                    title = "Favoured items";
                    break;
                
                case UserAction.Uploaded:
                    while (results.Read())
                    {
                        total++;
                        if (!detail) continue;
                        sb.AppendLine(HttpUtility.HtmlDecode(results["Target"].ToString()));
                    }
                    title = "Uploads";
                    break;
            }
            
            sb.Insert(0, BuildRptTitle(title, total,chkRptShowDetail.Checked));
            return Resources.Form1_NewLineCharacters + sb;
        }

        private static string BuildRptTitle(string heading, int total, bool detailed)
        {
            var title = heading + " " + total;
            var length = title.Length;
            if(detailed)
            {
                title += "\r\n";
                for (var i = 0; i < length; i++)
                    title += "-";
                title += "\r\n";
            }
            return title;
        }
        
        private static string GetRptQueryText(UserAction userAction, string user)
        {
            var query = string.Empty;
            var action = PageParser.GetActionText(userAction);

            switch (userAction)
            {
                case UserAction.AddedComment:
                    query = Settings.Default.sqlRptComments;
                    break;
                case UserAction.Subscribed:
                    query = Settings.Default.sqlRptSubscribed;
                    break;
                case UserAction.Unsubscribed:
                    query = Settings.Default.sqlRptUnSubscribed;
                    break;
                case UserAction.VotedOnItem:
                    query = Settings.Default.sqlRptVotedOnItems;
                    break;
                case UserAction.VotedUp:
                    query = Settings.Default.sqlRptVotedUp;
                    break;
                case UserAction.VotedDown:
                    query = Settings.Default.sqlRptVotedDown;
                    break;
                case UserAction.Favoured:
                    query = Settings.Default.sqlRptFavoured;
                    break;
                case UserAction.Uploaded:
                    query = Settings.Default.sqlRptUploads;
                    break;
            }
            query = query.Replace("[-ACTION-]", action);
            query = query.Replace("[-USER-]", user);

            return query;
        }

        private void tmrReports_Tick(object sender, EventArgs e)
        {
            GetBarChartData(cboTop10ReportName.SelectedValue.ToString());
        }

        #endregion

        

        

        
    }
}