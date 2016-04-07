namespace Tao.LAS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblUsernames = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboUserActions = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDataRetrieval = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtHistoryDepth = new System.Windows.Forms.TextBox();
            this.TargetUrl = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnGo = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tpUserActions = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUAAutoUpdate = new System.Windows.Forms.CheckBox();
            this.btnUAFind = new System.Windows.Forms.Button();
            this.cboUserName = new System.Windows.Forms.ComboBox();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.tpTargets = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgTargets = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetName = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblTargetCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tpTopTen = new System.Windows.Forms.TabPage();
            this.lblChooseChartData = new System.Windows.Forms.Label();
            this.cboTop10ReportName = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpReports = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnFullReport = new System.Windows.Forms.Button();
            this.chkRptShowDetail = new System.Windows.Forms.CheckBox();
            this.btnRptCopy = new System.Windows.Forms.Button();
            this.lblRptUserName = new System.Windows.Forms.Label();
            this.btnRtpClear = new System.Windows.Forms.Button();
            this.btnRptHeader = new System.Windows.Forms.Button();
            this.bntRptUploads = new System.Windows.Forms.Button();
            this.btnFavoured = new System.Windows.Forms.Button();
            this.btnRptComments = new System.Windows.Forms.Button();
            this.btnSubscriptions = new System.Windows.Forms.Button();
            this.btnRptItemVotes = new System.Windows.Forms.Button();
            this.btnRptUpVotes = new System.Windows.Forms.Button();
            this.txtRptUserName = new System.Windows.Forms.TextBox();
            this.btnRptDownVotes = new System.Windows.Forms.Button();
            this.txtRptOutput = new System.Windows.Forms.TextBox();
            this.tpDbFunctions = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnViewErrors = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tpParseTest = new System.Windows.Forms.TabPage();
            this.txtParseInput = new System.Windows.Forms.TextBox();
            this.txtParseOutput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSampleSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalErrors = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAccuracy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHistoryDepth = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUpTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrReports = new System.Windows.Forms.Timer(this.components);
            this.lblNoData = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpDataRetrieval.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tpUserActions.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpTargets.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTargets)).BeginInit();
            this.panel5.SuspendLayout();
            this.tpTopTen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tpReports.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tpDbFunctions.SuspendLayout();
            this.tpParseTest.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsernames
            // 
            this.lblUsernames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsernames.Location = new System.Drawing.Point(15, 12);
            this.lblUsernames.Name = "lblUsernames";
            this.lblUsernames.Size = new System.Drawing.Size(96, 13);
            this.lblUsernames.TabIndex = 4;
            this.lblUsernames.Text = "Usernames";
            this.lblUsernames.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Action";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboUserActions
            // 
            this.cboUserActions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUserActions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUserActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserActions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboUserActions.FormattingEnabled = true;
            this.cboUserActions.Location = new System.Drawing.Point(115, 35);
            this.cboUserActions.Name = "cboUserActions";
            this.cboUserActions.Size = new System.Drawing.Size(197, 21);
            this.cboUserActions.TabIndex = 2;
            this.cboUserActions.SelectedIndexChanged += new System.EventHandler(this.cboUserActions_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tpDataRetrieval);
            this.tabControl1.Controls.Add(this.tpTopTen);
            this.tabControl1.Controls.Add(this.tpUserActions);
            this.tabControl1.Controls.Add(this.tpTargets);
            this.tabControl1.Controls.Add(this.tpReports);
            this.tabControl1.Controls.Add(this.tpDbFunctions);
            this.tabControl1.Controls.Add(this.tpParseTest);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 426);
            this.tabControl1.TabIndex = 12;
            // 
            // tpDataRetrieval
            // 
            this.tpDataRetrieval.Controls.Add(this.panel3);
            this.tpDataRetrieval.Controls.Add(this.panel2);
            this.tpDataRetrieval.Location = new System.Drawing.Point(4, 25);
            this.tpDataRetrieval.Name = "tpDataRetrieval";
            this.tpDataRetrieval.Padding = new System.Windows.Forms.Padding(3);
            this.tpDataRetrieval.Size = new System.Drawing.Size(636, 397);
            this.tpDataRetrieval.TabIndex = 0;
            this.tpDataRetrieval.Text = "Data Retrieval";
            this.tpDataRetrieval.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtHistoryDepth);
            this.panel3.Controls.Add(this.TargetUrl);
            this.panel3.Controls.Add(this.webBrowser1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(630, 333);
            this.panel3.TabIndex = 15;
            // 
            // txtHistoryDepth
            // 
            this.txtHistoryDepth.Location = new System.Drawing.Point(513, 40);
            this.txtHistoryDepth.Name = "txtHistoryDepth";
            this.txtHistoryDepth.Size = new System.Drawing.Size(71, 20);
            this.txtHistoryDepth.TabIndex = 7;
            this.txtHistoryDepth.Visible = false;
            // 
            // TargetUrl
            // 
            this.TargetUrl.Location = new System.Drawing.Point(-13, 40);
            this.TargetUrl.Name = "TargetUrl";
            this.TargetUrl.Size = new System.Drawing.Size(517, 20);
            this.TargetUrl.TabIndex = 6;
            this.TargetUrl.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(626, 329);
            this.webBrowser1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.btnGo);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 58);
            this.panel2.TabIndex = 14;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(8, 32);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(58, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(72, 20);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnGo
            // 
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(8, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(58, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(138, 5);
            this.trackBar1.Maximum = 9999;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(482, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // tpUserActions
            // 
            this.tpUserActions.Controls.Add(this.panel4);
            this.tpUserActions.Controls.Add(this.panel1);
            this.tpUserActions.Location = new System.Drawing.Point(4, 25);
            this.tpUserActions.Name = "tpUserActions";
            this.tpUserActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserActions.Size = new System.Drawing.Size(636, 397);
            this.tpUserActions.TabIndex = 1;
            this.tpUserActions.Text = "User Actions";
            this.tpUserActions.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(630, 313);
            this.panel4.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(630, 313);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkUAAutoUpdate);
            this.panel1.Controls.Add(this.btnUAFind);
            this.panel1.Controls.Add(this.cboUserName);
            this.panel1.Controls.Add(this.cboUserActions);
            this.panel1.Controls.Add(this.lblRecordCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblUsernames);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 78);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Double click rows to open the comment or page";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUAAutoUpdate
            // 
            this.chkUAAutoUpdate.AutoSize = true;
            this.chkUAAutoUpdate.Location = new System.Drawing.Point(399, 11);
            this.chkUAAutoUpdate.Name = "chkUAAutoUpdate";
            this.chkUAAutoUpdate.Size = new System.Drawing.Size(86, 17);
            this.chkUAAutoUpdate.TabIndex = 16;
            this.chkUAAutoUpdate.Text = "Auto Update";
            this.chkUAAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // btnUAFind
            // 
            this.btnUAFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUAFind.Location = new System.Drawing.Point(318, 10);
            this.btnUAFind.Name = "btnUAFind";
            this.btnUAFind.Size = new System.Drawing.Size(75, 46);
            this.btnUAFind.TabIndex = 15;
            this.btnUAFind.Text = "Find";
            this.btnUAFind.UseVisualStyleBackColor = true;
            this.btnUAFind.Click += new System.EventHandler(this.btnUAFind_Click);
            // 
            // cboUserName
            // 
            this.cboUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboUserName.FormattingEnabled = true;
            this.cboUserName.Location = new System.Drawing.Point(115, 10);
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.Size = new System.Drawing.Size(197, 21);
            this.cboUserName.TabIndex = 13;
            this.cboUserName.SelectedIndexChanged += new System.EventHandler(this.cboUserName_SelectedIndexChanged);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(112, 59);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(0, 13);
            this.lblRecordCount.TabIndex = 12;
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpTargets
            // 
            this.tpTargets.Controls.Add(this.panel6);
            this.tpTargets.Controls.Add(this.panel5);
            this.tpTargets.Location = new System.Drawing.Point(4, 25);
            this.tpTargets.Name = "tpTargets";
            this.tpTargets.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargets.Size = new System.Drawing.Size(636, 397);
            this.tpTargets.TabIndex = 4;
            this.tpTargets.Text = "User Targets";
            this.tpTargets.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgTargets);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 68);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(630, 326);
            this.panel6.TabIndex = 15;
            // 
            // dgTargets
            // 
            this.dgTargets.AllowUserToAddRows = false;
            this.dgTargets.AllowUserToDeleteRows = false;
            this.dgTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTargets.Location = new System.Drawing.Point(0, 0);
            this.dgTargets.Name = "dgTargets";
            this.dgTargets.ReadOnly = true;
            this.dgTargets.Size = new System.Drawing.Size(630, 326);
            this.dgTargets.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtTargetName);
            this.panel5.Controls.Add(this.btnFind);
            this.panel5.Controls.Add(this.lblTargetCount);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(630, 65);
            this.panel5.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(349, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Double click rows to open the comment or page";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTargetName
            // 
            this.txtTargetName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTargetName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTargetName.Location = new System.Drawing.Point(65, 17);
            this.txtTargetName.Name = "txtTargetName";
            this.txtTargetName.Size = new System.Drawing.Size(194, 20);
            this.txtTargetName.TabIndex = 15;
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(264, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTargetCount
            // 
            this.lblTargetCount.AutoSize = true;
            this.lblTargetCount.Location = new System.Drawing.Point(67, 43);
            this.lblTargetCount.Name = "lblTargetCount";
            this.lblTargetCount.Size = new System.Drawing.Size(0, 13);
            this.lblTargetCount.TabIndex = 12;
            this.lblTargetCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(4, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Username";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpTopTen
            // 
            this.tpTopTen.Controls.Add(this.lblNoData);
            this.tpTopTen.Controls.Add(this.lblChooseChartData);
            this.tpTopTen.Controls.Add(this.cboTop10ReportName);
            this.tpTopTen.Controls.Add(this.chart1);
            this.tpTopTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTopTen.Location = new System.Drawing.Point(4, 25);
            this.tpTopTen.Name = "tpTopTen";
            this.tpTopTen.Padding = new System.Windows.Forms.Padding(3);
            this.tpTopTen.Size = new System.Drawing.Size(636, 397);
            this.tpTopTen.TabIndex = 2;
            this.tpTopTen.Text = "Top Ten\'s";
            this.tpTopTen.UseVisualStyleBackColor = true;
            // 
            // lblChooseChartData
            // 
            this.lblChooseChartData.AutoSize = true;
            this.lblChooseChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseChartData.Location = new System.Drawing.Point(8, 10);
            this.lblChooseChartData.Name = "lblChooseChartData";
            this.lblChooseChartData.Size = new System.Drawing.Size(106, 16);
            this.lblChooseChartData.TabIndex = 3;
            this.lblChooseChartData.Text = "Choose report";
            // 
            // cboTop10ReportName
            // 
            this.cboTop10ReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTop10ReportName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTop10ReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTop10ReportName.FormattingEnabled = true;
            this.cboTop10ReportName.Location = new System.Drawing.Point(120, 7);
            this.cboTop10ReportName.Name = "cboTop10ReportName";
            this.cboTop10ReportName.Size = new System.Drawing.Size(245, 24);
            this.cboTop10ReportName.TabIndex = 1;
            this.cboTop10ReportName.SelectedIndexChanged += new System.EventHandler(this.cboTop10ReportName_SelectedIndexChanged);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MaximumAutoSize = 80F;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MaximumAutoSize = 70F;
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Blue;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 33);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(630, 358);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title1.Name = "Title1";
            title1.Text = "TITLE1";
            title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow;
            this.chart1.Titles.Add(title1);
            // 
            // tpReports
            // 
            this.tpReports.Controls.Add(this.panel7);
            this.tpReports.Controls.Add(this.txtRptOutput);
            this.tpReports.Location = new System.Drawing.Point(4, 25);
            this.tpReports.Name = "tpReports";
            this.tpReports.Padding = new System.Windows.Forms.Padding(3);
            this.tpReports.Size = new System.Drawing.Size(636, 397);
            this.tpReports.TabIndex = 6;
            this.tpReports.Text = "Reports";
            this.tpReports.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnFullReport);
            this.panel7.Controls.Add(this.chkRptShowDetail);
            this.panel7.Controls.Add(this.btnRptCopy);
            this.panel7.Controls.Add(this.lblRptUserName);
            this.panel7.Controls.Add(this.btnRtpClear);
            this.panel7.Controls.Add(this.btnRptHeader);
            this.panel7.Controls.Add(this.bntRptUploads);
            this.panel7.Controls.Add(this.btnFavoured);
            this.panel7.Controls.Add(this.btnRptComments);
            this.panel7.Controls.Add(this.btnSubscriptions);
            this.panel7.Controls.Add(this.btnRptItemVotes);
            this.panel7.Controls.Add(this.btnRptUpVotes);
            this.panel7.Controls.Add(this.txtRptUserName);
            this.panel7.Controls.Add(this.btnRptDownVotes);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(630, 90);
            this.panel7.TabIndex = 1;
            // 
            // btnFullReport
            // 
            this.btnFullReport.Location = new System.Drawing.Point(441, 5);
            this.btnFullReport.Name = "btnFullReport";
            this.btnFullReport.Size = new System.Drawing.Size(169, 23);
            this.btnFullReport.TabIndex = 27;
            this.btnFullReport.Text = "Full Report";
            this.btnFullReport.UseVisualStyleBackColor = true;
            this.btnFullReport.Click += new System.EventHandler(this.btnFullReport_Click);
            // 
            // chkRptShowDetail
            // 
            this.chkRptShowDetail.AutoSize = true;
            this.chkRptShowDetail.Location = new System.Drawing.Point(320, 6);
            this.chkRptShowDetail.Name = "chkRptShowDetail";
            this.chkRptShowDetail.Size = new System.Drawing.Size(88, 17);
            this.chkRptShowDetail.TabIndex = 26;
            this.chkRptShowDetail.Text = "Show Details";
            this.chkRptShowDetail.UseVisualStyleBackColor = true;
            // 
            // btnRptCopy
            // 
            this.btnRptCopy.Location = new System.Drawing.Point(535, 30);
            this.btnRptCopy.Name = "btnRptCopy";
            this.btnRptCopy.Size = new System.Drawing.Size(75, 49);
            this.btnRptCopy.TabIndex = 25;
            this.btnRptCopy.Text = "Copy report to clipboard";
            this.btnRptCopy.UseVisualStyleBackColor = true;
            this.btnRptCopy.Click += new System.EventHandler(this.btnRptCopy_Click);
            // 
            // lblRptUserName
            // 
            this.lblRptUserName.AutoSize = true;
            this.lblRptUserName.Location = new System.Drawing.Point(5, 7);
            this.lblRptUserName.Name = "lblRptUserName";
            this.lblRptUserName.Size = new System.Drawing.Size(35, 13);
            this.lblRptUserName.TabIndex = 16;
            this.lblRptUserName.Text = "User :";
            this.lblRptUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRtpClear
            // 
            this.btnRtpClear.Location = new System.Drawing.Point(441, 30);
            this.btnRtpClear.Name = "btnRtpClear";
            this.btnRtpClear.Size = new System.Drawing.Size(75, 49);
            this.btnRtpClear.TabIndex = 24;
            this.btnRtpClear.Text = "Clear";
            this.btnRtpClear.UseVisualStyleBackColor = true;
            this.btnRtpClear.Click += new System.EventHandler(this.btnRtpClear_Click);
            // 
            // btnRptHeader
            // 
            this.btnRptHeader.Location = new System.Drawing.Point(320, 56);
            this.btnRptHeader.Name = "btnRptHeader";
            this.btnRptHeader.Size = new System.Drawing.Size(99, 23);
            this.btnRptHeader.TabIndex = 23;
            this.btnRptHeader.Text = "Header";
            this.btnRptHeader.UseVisualStyleBackColor = true;
            this.btnRptHeader.Click += new System.EventHandler(this.btnRptHeader_Click);
            // 
            // bntRptUploads
            // 
            this.bntRptUploads.Location = new System.Drawing.Point(320, 30);
            this.bntRptUploads.Name = "bntRptUploads";
            this.bntRptUploads.Size = new System.Drawing.Size(99, 23);
            this.bntRptUploads.TabIndex = 22;
            this.bntRptUploads.Text = "Uploads";
            this.bntRptUploads.UseVisualStyleBackColor = true;
            this.bntRptUploads.Click += new System.EventHandler(this.bntRptUploads_Click);
            // 
            // btnFavoured
            // 
            this.btnFavoured.Location = new System.Drawing.Point(215, 56);
            this.btnFavoured.Name = "btnFavoured";
            this.btnFavoured.Size = new System.Drawing.Size(99, 23);
            this.btnFavoured.TabIndex = 21;
            this.btnFavoured.Text = "Favoured";
            this.btnFavoured.UseVisualStyleBackColor = true;
            this.btnFavoured.Click += new System.EventHandler(this.btnFavoured_Click);
            // 
            // btnRptComments
            // 
            this.btnRptComments.Location = new System.Drawing.Point(110, 30);
            this.btnRptComments.Name = "btnRptComments";
            this.btnRptComments.Size = new System.Drawing.Size(99, 23);
            this.btnRptComments.TabIndex = 20;
            this.btnRptComments.Text = "Comments";
            this.btnRptComments.UseVisualStyleBackColor = true;
            this.btnRptComments.Click += new System.EventHandler(this.btnRptComments_Click);
            // 
            // btnSubscriptions
            // 
            this.btnSubscriptions.Location = new System.Drawing.Point(215, 30);
            this.btnSubscriptions.Name = "btnSubscriptions";
            this.btnSubscriptions.Size = new System.Drawing.Size(99, 23);
            this.btnSubscriptions.TabIndex = 19;
            this.btnSubscriptions.Text = "Subscriptions";
            this.btnSubscriptions.UseVisualStyleBackColor = true;
            this.btnSubscriptions.Click += new System.EventHandler(this.btnSubscriptions_Click);
            // 
            // btnRptItemVotes
            // 
            this.btnRptItemVotes.Location = new System.Drawing.Point(110, 56);
            this.btnRptItemVotes.Name = "btnRptItemVotes";
            this.btnRptItemVotes.Size = new System.Drawing.Size(99, 23);
            this.btnRptItemVotes.TabIndex = 18;
            this.btnRptItemVotes.Text = "ItemVotes";
            this.btnRptItemVotes.UseVisualStyleBackColor = true;
            this.btnRptItemVotes.Click += new System.EventHandler(this.btnRptItemVotes_Click);
            // 
            // btnRptUpVotes
            // 
            this.btnRptUpVotes.Location = new System.Drawing.Point(5, 30);
            this.btnRptUpVotes.Name = "btnRptUpVotes";
            this.btnRptUpVotes.Size = new System.Drawing.Size(99, 23);
            this.btnRptUpVotes.TabIndex = 17;
            this.btnRptUpVotes.Text = "Up Votes";
            this.btnRptUpVotes.UseVisualStyleBackColor = true;
            this.btnRptUpVotes.Click += new System.EventHandler(this.btnRptUpVotes_Click);
            // 
            // txtRptUserName
            // 
            this.txtRptUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRptUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRptUserName.Location = new System.Drawing.Point(40, 4);
            this.txtRptUserName.Name = "txtRptUserName";
            this.txtRptUserName.Size = new System.Drawing.Size(274, 20);
            this.txtRptUserName.TabIndex = 16;
            // 
            // btnRptDownVotes
            // 
            this.btnRptDownVotes.Location = new System.Drawing.Point(5, 56);
            this.btnRptDownVotes.Name = "btnRptDownVotes";
            this.btnRptDownVotes.Size = new System.Drawing.Size(99, 23);
            this.btnRptDownVotes.TabIndex = 0;
            this.btnRptDownVotes.Text = "Down Votes";
            this.btnRptDownVotes.UseVisualStyleBackColor = true;
            this.btnRptDownVotes.Click += new System.EventHandler(this.btnRptDownVotes_Click);
            // 
            // txtRptOutput
            // 
            this.txtRptOutput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRptOutput.Location = new System.Drawing.Point(3, 99);
            this.txtRptOutput.Multiline = true;
            this.txtRptOutput.Name = "txtRptOutput";
            this.txtRptOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRptOutput.Size = new System.Drawing.Size(630, 295);
            this.txtRptOutput.TabIndex = 0;
            // 
            // tpDbFunctions
            // 
            this.tpDbFunctions.Controls.Add(this.button4);
            this.tpDbFunctions.Controls.Add(this.textBox1);
            this.tpDbFunctions.Controls.Add(this.btnViewErrors);
            this.tpDbFunctions.Controls.Add(this.button3);
            this.tpDbFunctions.Controls.Add(this.button2);
            this.tpDbFunctions.Location = new System.Drawing.Point(4, 25);
            this.tpDbFunctions.Name = "tpDbFunctions";
            this.tpDbFunctions.Padding = new System.Windows.Forms.Padding(3);
            this.tpDbFunctions.Size = new System.Drawing.Size(636, 397);
            this.tpDbFunctions.TabIndex = 3;
            this.tpDbFunctions.Text = "Db functions";
            this.tpDbFunctions.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(231, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(217, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Upgrade Database";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 123);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(620, 268);
            this.textBox1.TabIndex = 3;
            this.textBox1.WordWrap = false;
            // 
            // btnViewErrors
            // 
            this.btnViewErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewErrors.Location = new System.Drawing.Point(8, 47);
            this.btnViewErrors.Name = "btnViewErrors";
            this.btnViewErrors.Size = new System.Drawing.Size(217, 23);
            this.btnViewErrors.TabIndex = 2;
            this.btnViewErrors.Text = "View errors";
            this.btnViewErrors.UseVisualStyleBackColor = true;
            this.btnViewErrors.Click += new System.EventHandler(this.btnViewErrors_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(8, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(217, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Compact Database";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(8, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Clear tables";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tpParseTest
            // 
            this.tpParseTest.Controls.Add(this.txtParseInput);
            this.tpParseTest.Controls.Add(this.txtParseOutput);
            this.tpParseTest.Controls.Add(this.button1);
            this.tpParseTest.Location = new System.Drawing.Point(4, 25);
            this.tpParseTest.Name = "tpParseTest";
            this.tpParseTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpParseTest.Size = new System.Drawing.Size(636, 397);
            this.tpParseTest.TabIndex = 5;
            this.tpParseTest.Text = "Parser Test";
            this.tpParseTest.UseVisualStyleBackColor = true;
            // 
            // txtParseInput
            // 
            this.txtParseInput.Location = new System.Drawing.Point(21, 49);
            this.txtParseInput.Multiline = true;
            this.txtParseInput.Name = "txtParseInput";
            this.txtParseInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtParseInput.Size = new System.Drawing.Size(293, 342);
            this.txtParseInput.TabIndex = 2;
            // 
            // txtParseOutput
            // 
            this.txtParseOutput.Location = new System.Drawing.Point(320, 49);
            this.txtParseOutput.Multiline = true;
            this.txtParseOutput.Name = "txtParseOutput";
            this.txtParseOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtParseOutput.Size = new System.Drawing.Size(293, 342);
            this.txtParseOutput.TabIndex = 1;
            this.txtParseOutput.Text = " ";
            this.txtParseOutput.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Parse page body text";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBar,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel2,
            this.lblSampleSize,
            this.toolStripStatusLabel4,
            this.lblTotalErrors,
            this.toolStripStatusLabel1,
            this.lblAccuracy,
            this.toolStripStatusLabel5,
            this.lblHistoryDepth,
            this.lblStatus,
            this.toolStripUpTimeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(644, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(150, 18);
            this.tsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(4, 19);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(74, 19);
            this.toolStripStatusLabel2.Text = "Sample size :";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSampleSize
            // 
            this.lblSampleSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblSampleSize.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblSampleSize.Margin = new System.Windows.Forms.Padding(-5, 3, 0, 2);
            this.lblSampleSize.Name = "lblSampleSize";
            this.lblSampleSize.Size = new System.Drawing.Size(35, 19);
            this.lblSampleSize.Text = "1000";
            this.lblSampleSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(43, 19);
            this.toolStripStatusLabel4.Text = "Errors :";
            // 
            // lblTotalErrors
            // 
            this.lblTotalErrors.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTotalErrors.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblTotalErrors.Margin = new System.Windows.Forms.Padding(-5, 3, 0, 2);
            this.lblTotalErrors.Name = "lblTotalErrors";
            this.lblTotalErrors.Size = new System.Drawing.Size(23, 19);
            this.lblTotalErrors.Text = "10";
            this.lblTotalErrors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 19);
            this.toolStripStatusLabel1.Text = "Acc :";
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblAccuracy.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblAccuracy.Margin = new System.Windows.Forms.Padding(-5, 3, 0, 2);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(27, 19);
            this.lblAccuracy.Text = "0%";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(45, 19);
            this.toolStripStatusLabel5.Text = "Depth :";
            // 
            // lblHistoryDepth
            // 
            this.lblHistoryDepth.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblHistoryDepth.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblHistoryDepth.Margin = new System.Windows.Forms.Padding(-5, 3, 0, 2);
            this.lblHistoryDepth.Name = "lblHistoryDepth";
            this.lblHistoryDepth.Size = new System.Drawing.Size(64, 19);
            this.lblHistoryDepth.Text = "1 min ago";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(149, 19);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripUpTimeLabel
            // 
            this.toolStripUpTimeLabel.Name = "toolStripUpTimeLabel";
            this.toolStripUpTimeLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // tmrReports
            // 
            this.tmrReports.Interval = 3000;
            this.tmrReports.Tick += new System.EventHandler(this.tmrReports_Tick);
            // 
            // lblNoData
            // 
            this.lblNoData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 51.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.Location = new System.Drawing.Point(3, 3);
            this.lblNoData.Margin = new System.Windows.Forms.Padding(0);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(630, 391);
            this.lblNoData.TabIndex = 0;
            this.lblNoData.Text = "No data found yet";
            this.lblNoData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoData.UseMnemonic = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 446);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LiveLeak Activity Spy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpDataRetrieval.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tpUserActions.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpTargets.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTargets)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tpTopTen.ResumeLayout(false);
            this.tpTopTen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tpReports.ResumeLayout(false);
            this.tpReports.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tpDbFunctions.ResumeLayout(false);
            this.tpDbFunctions.PerformLayout();
            this.tpParseTest.ResumeLayout(false);
            this.tpParseTest.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsernames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboUserActions;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDataRetrieval;
        private System.Windows.Forms.TabPage tpUserActions;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.TabPage tpTopTen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblChooseChartData;
        private System.Windows.Forms.ComboBox cboTop10ReportName;
        private System.Windows.Forms.TabPage tpDbFunctions;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblSampleSize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalErrors;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblHistoryDepth;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblAccuracy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtHistoryDepth;
        private System.Windows.Forms.TextBox TargetUrl;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboUserName;
        private System.Windows.Forms.TabPage tpTargets;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgTargets;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTargetCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtTargetName;
        private System.Windows.Forms.Button btnViewErrors;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tpParseTest;
        private System.Windows.Forms.TextBox txtParseInput;
        private System.Windows.Forms.TextBox txtParseOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tpReports;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnRptDownVotes;
        private System.Windows.Forms.TextBox txtRptOutput;
        private System.Windows.Forms.TextBox txtRptUserName;
        private System.Windows.Forms.Button btnRptUpVotes;
        private System.Windows.Forms.Button btnRptItemVotes;
        private System.Windows.Forms.Button btnSubscriptions;
        private System.Windows.Forms.Button btnRptComments;
        private System.Windows.Forms.Button btnFavoured;
        private System.Windows.Forms.Button bntRptUploads;
        private System.Windows.Forms.Button btnRtpClear;
        private System.Windows.Forms.Button btnRptHeader;
        private System.Windows.Forms.Label lblRptUserName;
        private System.Windows.Forms.Button btnUAFind;
        private System.Windows.Forms.CheckBox chkUAAutoUpdate;
        private System.Windows.Forms.Button btnRptCopy;
        private System.Windows.Forms.CheckBox chkRptShowDetail;
        private System.Windows.Forms.Button btnFullReport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUpTimeLabel;
        private System.Windows.Forms.Timer tmrReports;
        private System.Windows.Forms.Label lblNoData;
    }
}

