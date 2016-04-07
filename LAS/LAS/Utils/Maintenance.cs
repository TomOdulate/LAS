using System;
using System.Data;
using System.Data.SqlServerCe;
using Tao.LAS.Properties;

namespace Tao.LAS.Utils
{
    class Maintenance
    {
        private readonly SqlCeConnection _conn;

        public Maintenance(SqlCeConnection ceConnection)
        {
            _conn = ceConnection;
        }

        public void ClearTables()
        {
            var cmdTableExists = _conn.CreateCommand();
            cmdTableExists.CommandType = CommandType.Text;
            cmdTableExists.CommandText = Properties.Settings.Default.sqlCheckTableExists.Replace("TARGET_TABLE", "UserActivity");

            _conn.Close();

            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            // Drop UserActivity table if it exists
            int r = int.Parse(cmdTableExists.ExecuteScalar().ToString());
            if (r == 1)
            {
                var dropCmd = _conn.CreateCommand();
                dropCmd.CommandType = CommandType.Text;
                dropCmd.CommandText = "DROP TABLE " + "UserActivity";
                dropCmd.ExecuteNonQuery();
            }

            // Drop ErrorLog table if it exists
            cmdTableExists.CommandText = Properties.Settings.Default.sqlCheckTableExists.Replace("TARGET_TABLE",
                "ErrorLog");
            r = int.Parse(cmdTableExists.ExecuteScalar().ToString());
            if (r == 1)
            {
                var dropCmd = _conn.CreateCommand();
                dropCmd.CommandType = CommandType.Text;
                dropCmd.CommandText = "DROP TABLE " + "ErrorLog";
                dropCmd.ExecuteNonQuery();
            }

            // (re)Create UserActivity table.
            var cmdCreateActivityTable = _conn.CreateCommand();
            cmdCreateActivityTable.CommandType = CommandType.Text;
            cmdCreateActivityTable.CommandText = Properties.Settings.Default.sqlCreateActivityTable;
            cmdCreateActivityTable.ExecuteNonQuery();

            // (re)Create ErrorLog table.
            var cmdCreateErrorLogTable = _conn.CreateCommand();
            cmdCreateErrorLogTable.CommandType = CommandType.Text;
            cmdCreateErrorLogTable.CommandText = Properties.Settings.Default.sqlCreateErrorLogTable;
            cmdCreateErrorLogTable.ExecuteNonQuery();
            _conn.Close();
        }

        public void CompactDb()
        {
            //if(_conn.State != ConnectionState.Closed)
            //    _conn.Close();

            //string src = Settings.Default.strDBFullPath;

            //string dest = src + ".tmp";

            //var engine = new SqlCeEngine(Settings.Default.LASDBConnectionString);
            //engine.Compact(Settings.Default.LASDBConnectionString + ".tmp");
            //engine.Dispose();

            //var a = engine.LocalConnectionString;

            //File.Delete(src);
            //File.Move(dest, src);
        }

        public void UpgragdeDb()
        {
            if (_conn.State != ConnectionState.Closed)
                _conn.Close();

            string src = Settings.Default.strDBFullPath;

            string dest = src + ".tmp";

            var engine = new SqlCeEngine("Data Source=D:\\Documents\\Visual Studio 2013\\Projects\\LAS\\LAS\\ActivityDB.sdf");//Settings.Default.LASDBConnectionString);
            
            engine.Upgrade();
            engine.Dispose();

            _conn.Close();
        }

        public static TimeSpan CalcUpTime(DateTime dtStartTime)
        {
            var currentTime = DateTime.Now;
            return currentTime.Subtract(dtStartTime);
        }
    }
}
