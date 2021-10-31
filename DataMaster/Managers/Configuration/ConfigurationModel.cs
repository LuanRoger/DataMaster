using DataMaster.Managers.Configuration.Sections;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace DataMaster.Managers.Configuration
{
    [SectionClass]
    public record ConfigurationModel : IConfigurationModel
    {
        public DatabaseConfigModel database { get; set; }
        public DatabaseConnectionsHistory connectionsHistory { get; set; }
        public CustomizationConfigModel customizationConfigModel { get; set; }
        public LanguageConfigModel languageConfigModel { get; set; }
    }
}
