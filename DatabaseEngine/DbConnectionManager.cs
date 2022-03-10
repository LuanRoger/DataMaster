using DatabaseEngine.DB;
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
            if(value == null)
                throw new MandatoryNonNullValue(nameof(value));
            
            DisposeAllDomains();
            _databaseProviderConnection = value;

            _sqlServerDomain = value.databaseProvider switch
            {
                DatabaseProvider.SqlServer => new(value.connectionString),
                _ => _sqlServerDomain
            };
        }
    }
    private static DatabaseProviderConnection? _databaseProviderConnection { get; set; }
    public static ISqlDriverCommands? currentProvider
    {
        get
        {
            if (_databaseProviderConnection == null)
                return null;

            return _databaseProviderConnection.databaseProvider switch
            {
                DatabaseProvider.SqlServer => _sqlServerDomain,
                _ => null
            };
        }
    }
    
    private static SqlServerDomain? _sqlServerDomain { get; set; }
    
    /// <summary>
    /// Try connect using the actual connection string and dispose all domains.
    /// </summary>
    /// <returns>true if could connect;
    /// false if couldn't connect;</returns>
    public static async Task<bool> TestConnection(bool dispose = true)
    {
        if(currentProvider == null)
            throw new MandatoryNonNullValue(nameof(currentProvider));

        bool getConnected = await currentProvider.TryOpenConnection();
        await currentProvider.TryCloseConnection();
        
        if(dispose)
            DisposeAllDomains();
        
        return getConnected;
    }
    
    private static void DisposeAllDomains()
    {
        _sqlServerDomain?.Dispose();
    }
}