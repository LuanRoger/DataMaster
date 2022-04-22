using System.Text;

namespace DataMaster.Util.ConnStringBuilder;

#nullable enable

public class ConnStringBuilderSqlServer : IConnStringBuilder
{
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
        set => _connectedServer = !string.IsNullOrEmpty(value) ? "Server=" + value + ";" : null;
    }
        
    private string? _connectedDatabase { get; set; }
    public string? connectionDatabase
    {
        get => RemoverIndicators(_connectedDatabase);
        set => _connectedDatabase = !string.IsNullOrEmpty(value)? "Database=" + value + ";" : null;
    }
        
    private string? _userId { get; set; }
    public string? userId
    {
        get => RemoverIndicators(_userId);
        set => _userId = !string.IsNullOrEmpty(value) ? "User Id=" + value + ";" : null;
    }
        
    private string? _password { get; set; }
    public string? password
    {
        get => RemoverIndicators(_password);
        set => _password = !string.IsNullOrEmpty(value) ? "Password=" + value + ";" : null;
    }
        
    private string? _trustedConnection { get; set; }
    public bool trustedConnection
    {
        get
        {
            string? triagedTrusted = RemoverIndicators(_trustedConnection);
                
            return triagedTrusted switch
            {
                "True" => true,
                "False" => false,
                _ => false
            };
        }
        set => _trustedConnection = value ? "Trusted_Connection=True;" : "Trusted_Connection=False;";
    }
        
    public void Clear()
    {
        _connectedServer = null;
        _connectedDatabase = null;
        _userId = null;
        _password = null;
    }

    private static string? RemoverIndicators(string? stringIndicator) =>
        stringIndicator?.Substring(stringIndicator.IndexOf('='), stringIndicator.IndexOf(';'));
}