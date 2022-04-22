using System.Text;

namespace DataMaster.Util.ConnStringBuilder;

public class ConnStringBuilderSqlite : IConnStringBuilder
{
    public string connectionString
    {
        get
        {
            StringBuilder connStringBuilder = new();
            
            connStringBuilder.Append(_dataSource);
            connStringBuilder.Append(_version);
            connStringBuilder.Append(_password);
            
            return connStringBuilder.ToString();
        }
    }

    private string? _dataSource { get; set; }
    public string? dataSource
    {
        get => RemoveIndicators(_dataSource);
        set => _dataSource = !string.IsNullOrEmpty(value) ? $"Data Source={value};" : null;
    }
    
    private string? _password { get; set; }
    public string? password
    {
        get => RemoveIndicators(_password);
        set => _password = !string.IsNullOrEmpty(value) ? $"Password={value};" : null;
    }
    
    private string? _version { get; set; }
    public string? version
    {
        get => RemoveIndicators(_version);
        set => _version = !string.IsNullOrEmpty(value) ? $"Version={value};" : null;
    }
    
    private string? _isReadOnly { get; set; }
    public bool isReadOnly
    {
        get => RemoveIndicators(_isReadOnly) switch
        {
            "True" => true,
            "False" => false,
            _ => false
        };
        set => _isReadOnly = value ? "Read Only = True" : "Read Only = False";
    }

    public void Clear()
    {
        _dataSource = null;
        _password = null;
        _version = null;
        _isReadOnly = null;
    }
    private static string? RemoveIndicators(string? stringIndicators) => 
        stringIndicators?.Substring(stringIndicators.IndexOf('='), stringIndicators.IndexOf(';'));
    
}