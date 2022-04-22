using DatabaseEngine.DB;
using DatabaseEngine.DB.SQLite;
using DatabaseEngine.DB.SQLServer;
using DatabaseEngine.Enums;
using DatabaseEngine.Exceptions;
using DatabaseEngine.Types;

namespace DatabaseEngine;

public static class DbConnectionManager
{
    public static DatabaseProviderConnection? databaseProviderConnection
    {
        get => _databaseProviderConnection;
        set
        {
            if(value is null)
                throw new MandatoryNonNullValue(nameof(value));
            
            DisposeAllDomains();
            _databaseProviderConnection = value;
            InitDomain();
        }
    }
    private static DatabaseProviderConnection? _databaseProviderConnection { get; set; }
    public static ISqlDriverCommands? currentProvider =>
        _databaseProviderConnection is null ? null : 
            _databaseProviderConnection.databaseProvider switch
        {
            DatabaseProvider.SqlServer => _sqlServerDomain,
            DatabaseProvider.Sqlite => _sqliteDomain,
            _ => null
        };

    private static SqlServerDomain? _sqlServerDomain { get; set; }
    private static SqliteDomain? _sqliteDomain { get; set; }
    
    /// <summary>
    /// Try connect using the actual connection string and dispose all domains.
    /// </summary>
    /// <returns>true if could connect;
    /// false if couldn't connect;</returns>
    public static async Task<bool> TestConnection(bool dispose = true)
    {
        if(currentProvider is null)
            throw new MandatoryNonNullValue(nameof(currentProvider));
        bool getConnected;
        try
        {
            getConnected = await currentProvider.TryOpenConnection();   
        }
        finally
        {
            await currentProvider.TryCloseConnection();   
        }

        if(dispose)
            DisposeAllDomains();
        
        return getConnected;
    }
    
    private static void InitDomain()
    {
        switch (_databaseProviderConnection.databaseProvider)
        {
            case DatabaseProvider.SqlServer:
                _sqlServerDomain = new(_databaseProviderConnection.connectionString);
                break;
            case DatabaseProvider.Sqlite:
                _sqliteDomain = new(_databaseProviderConnection.connectionString);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private static void DisposeAllDomains()
    {
        _sqlServerDomain?.Dispose();
        _sqliteDomain?.Dispose();
        
        _databaseProviderConnection = null;
    }
}