using DataMaster.Managers.Configuration.Sections;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace DataMaster.Managers.Configuration
{
    [SectionClass]
    public record ConfigurationModel : IConfigurationModel
    {
        [Section]
        public DatabaseConfigModel database { get; set; }
        [Section]
        public DatabaseConnectionsHistory connectionsHistory { get; set; }
        [Section]
        public CustomizationConfigModel customizationConfigModel { get; set; }
    }
}
