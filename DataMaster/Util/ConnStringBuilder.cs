using System;
using System.Text;

namespace DataMaster.Util
{
    public static class ConnStringBuilder
    {
        #nullable enable
        public static string connectionString
        {
            get
            {
                StringBuilder connStringBuilder = new();
                
                connStringBuilder.Append(_connectedServer);
                connStringBuilder.Append(_connectedDatabase);
                connStringBuilder.Append(_userId);
                connStringBuilder.Append(_password);
                connStringBuilder.Append(_trustedConnection);
                
                return connStringBuilder.ToString();
            }
        }

        private static string? _connectedServer { get; set; }
        public static string? connectionServer
        {
            get => RemoverIndicators(_connectedServer);
            set => _connectedServer = "Server=" + value + ";";
        }
        private static string? _connectedDatabase {get; set;}
        public static string? connectionDatabase
        {
            get => RemoverIndicators(_connectedDatabase);
            set
            {
                if(value != null) _connectedDatabase = "Database=" + value + ";";
            }
        }
        private static string? _userId {get; set;}
        public static string? userId
        {
            get => RemoverIndicators(_userId);
            set
            {
                if(value != null) _userId = "User Id=" + value + ";";
            } 
        }
        private static string? _password {get; set;}
        public static string? password
        {
            get => RemoverIndicators(_password);
            set
            {
                if(value != null) _password = "Password=" + value + ";";
            } 
        }
        private static string _trustedConnection {get; set;}
        public static bool trustedConnection
        {
            get
            {
                string triagedTrusted = RemoverIndicators(_trustedConnection);
                
                return triagedTrusted switch
                {
                    "True" => true,
                    "False" => false,
                    _ => throw new ArgumentException("Trusded paramater not is valid")
                };
            }
            set
            {
                _trustedConnection = value switch
                {
                    true => "Trusted_Connection=True;",
                    false => "Trusted_Connection=False;"
                };
            }
        }
        
        public static void ClearConnectionStringBuilder()
        {
            _connectedServer = null;
            _connectedDatabase = null;
            _userId = null;
            _password = null;
        }

        private static string RemoverIndicators(string databaseIndicator) =>
            databaseIndicator.Remove(databaseIndicator.IndexOf('='), databaseIndicator.IndexOf(';'));
    }
}