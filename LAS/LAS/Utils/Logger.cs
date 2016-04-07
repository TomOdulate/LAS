using System.Data;
using System.Data.SqlServerCe;
using System.Web;
using Tao.LAS.Properties;

namespace Tao.LAS.Utils
{
    static class Logger
    {
        public static void LogError(string message)
        {
            var cn = new SqlCeConnection(Settings.Default.LASDBConnectionString);
            
            try
            {
                if(cn.State != ConnectionState.Open)
                    cn.Open();

                var queryStr = "INSERT INTO ErrorLog (Time, Message) VALUES ("
                               + "'" + "" + "',"
                               + "'" + HttpUtility.HtmlEncode(message) + "'"
                               + ")";

                var insertCommand = new SqlCeCommand(queryStr, cn);
                insertCommand.ExecuteNonQuery();    
            }
            catch(SqlCeException)
            {
                //
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
