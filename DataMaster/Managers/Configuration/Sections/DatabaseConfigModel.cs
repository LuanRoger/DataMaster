using DataMaster.Types;
using System.Text.Json.Serialization;

namespace DataMaster.Managers.Configuration.Sections
{
    public record DatabaseConfigModel
    {
        public string ConnectionString {get; set;}
        public ConnectionType connectionType {get; set;}
    }
}
