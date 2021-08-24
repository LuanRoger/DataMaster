using System.Collections.Generic;
using SerializedConfig.Types;

namespace DataMaster.Managers.Configuration.Sections
{
    public record DatabaseConnectionsHistory
    {
        public List<string> historyConnections { get; set; }
    }
}