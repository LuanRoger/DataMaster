using System.Collections.Generic;

#pragma warning disable CS8618

namespace DataMaster.Managers.Configuration.Sections;

public class DatabaseConnectionsHistory
{
    public List<string> historyConnections { get; set; }
}