using System;
using System.Text;

namespace DataMaster.Util;

//TODO: Made clonable
public class ConnStringBuilder
{
#nullable enable
    public string connectionString
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

    private string? _connectedServer { get; set; }
    public string? connectionServer
    {
        get => RemoverIndicators(_connectedServer);
        set => _connectedServer = "Server=" + value + ";";
    }
        
    private string? _connectedDatabase { get; set; }
    public string? connectionDatabase
    {
        get => RemoverIndicators(_connectedDatabase);
        set
        {
            if(value != null) _connectedDatabase = "Database=" + value + ";";
        }
    }
        
    private string? _userId { get; set; }
    public string? userId
    {
        get => RemoverIndicators(_userId);
        set
        {
            if(value != null) _userId = "User Id=" + value + ";";
        } 
    }
        
    private string? _password { get; set; }
    public string? password
    {
        get => RemoverIndicators(_password);
        set
        {
            if(value != null) _password = "Password=" + value + ";";
        } 
    }
        
    private string _trustedConnection { get; set; }
    public bool trustedConnection
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
        
    public void ClearConnectionStringBuilder()
    {
        _connectedServer = null;
        _connectedDatabase = null;
        _userId = null;
        _password = null;
    }

    private string? RemoverIndicators(string? databaseIndicator) =>
        databaseIndicator?.Remove(databaseIndicator.IndexOf('='), databaseIndicator.IndexOf(';'));
}