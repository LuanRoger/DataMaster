using DataMaster.Types;
using System.Data.SqlClient;
using DataMaster.Managers.Configuration;
using DataMaster.Util;

namespace DataMaster.Managers
{
    public static class DbConnectionManager
    {
        public static SqlConnection sqlServerConnection =>
            new(AppConfigurationManager.configuration.database.connectionString);
        
        public static AuthTypes authenticationType {get; set;}
        
        public static string GetConnectedDatabase()
        {
            if(!sqlServerConnection.ConnectionString.Contains("Database=")) return null;
            
            int start, end;
            start = sqlServerConnection.ConnectionString.IndexOf("Database=") + "Database=".Length;
            end = sqlServerConnection.ConnectionString.IndexOf(';', start);
            return sqlServerConnection.ConnectionString
                .Substring(start, end - start);
        }
        public static string GetConnectedServer()
        {
            if(!sqlServerConnection.ConnectionString.Contains("Server=")) return null;
            
            int start, end;
            start = sqlServerConnection.ConnectionString.IndexOf("Server=") + "Server=".Length;
            end = sqlServerConnection.ConnectionString.IndexOf(';', start);
            return sqlServerConnection.ConnectionString
                .Substring(start, end - start);
        }
        
        public static void SaveConnStringByConnStringBuilder()
        {
            AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
            {
                connectionString = ConnStringBuilder.connectionString,
            };
            AppConfigurationManager.SaveConfig();
            ConnStringBuilder.ClearConnectionStringBuilder();
        }
    }
}
