using System.Collections.Generic;

namespace DataMaster.Managers.Configuration.Sections
{
    public record DatabaseConnectionsHistory
    {
        public List<string> historyConnections { get; set; }
    }
}