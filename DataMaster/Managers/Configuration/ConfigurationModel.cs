using DataMaster.Managers.Configuration.Sections;
using SerializedConfig.Types;

namespace DataMaster.Managers.Configuration
{
    public record ConfigurationModel : IConfigurationModel
    {
        [Section]
        public DatabaseConfigModel database { get; set; }
        [Section]
        public DatabaseConnectionsHistory connectionsHistory { get; set; }
    }
}
