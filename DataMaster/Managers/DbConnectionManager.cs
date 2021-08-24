using DataMaster.Types;
using System.Data.SqlClient;
using DataMaster.Managers.Configuration;
using DataMaster.Util;

namespace DataMaster.Managers
{
    public static class DbConnectionManager
    {
        public static readonly SqlConnection sqlServerConnection =
            new(AppConfigurationManager.configuration.database.ConnectionString);
        
        public static ConnectionType connectionType  =
            AppConfigurationManager.configuration.database.connectionType;
        public static AuthTypes authenticationType {get; set;}
        
        public static string GetConnectedDatabase()
        {
            switch (connectionType)
            {
                case ConnectionType.SqlPure:
                    int start, end;
                    start = sqlServerConnection.ConnectionString.IndexOf("Database=") + "Database=".Length;
                    end = sqlServerConnection.ConnectionString.IndexOf(';', start);
                    return sqlServerConnection.ConnectionString
                        .Substring(start, end - start);
                case ConnectionType.EF:
                    break;
                default:
                    throw new ("Not supported connection");
            }
            return null;
        }
        public static string GetConnectedServer()
        {
            switch (connectionType)
            {
                case ConnectionType.SqlPure:
                    int start, end;
                    start = sqlServerConnection.ConnectionString.IndexOf("Server=") + "Server=".Length;
                    end = sqlServerConnection.ConnectionString.IndexOf(';', start);
                    return sqlServerConnection.ConnectionString
                        .Substring(start, end - start);
                case ConnectionType.EF:
                    break;
                default:
                    throw new ("Not supported connection");
            }
            return null;
        }
        
        public static void SaveConnString()
        {
            AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
            {
                ConnectionString = ConnStringBuilder.connectionString,
                connectionType = connectionType
            };
            AppConfigurationManager.SaveConfig();
            ConnStringBuilder.ClearConnectionStringBuilder();
        }
    }
}
