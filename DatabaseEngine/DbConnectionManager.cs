using DatabaseEngine.DB;
using DatabaseEngine.DB.SQLServer;
using DatabaseEngine.Enums;
using DatabaseEngine.Types;

namespace DatabaseEngine;

//TODO: Made non-static
public static class DbConnectionManager
{
    public static DatabaseProviderConnection? databaseProviderConnection
    {
        get => _databaseProviderConnection;
        set
        {
            if(value == null)
                throw new ArgumentNullException(); //TODO: Create a exception type for null mandatory non-null entryes
            
            DisposeAllDomains();
            _databaseProviderConnection = value;

            switch (value.databaseProvider)
            {
                case DatabaseProvider.SqlServer:
                    _sqlServerDomain = new(value.connectionString);
                    break;
            }
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
            throw new ArgumentNullException();

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