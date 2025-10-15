using System.Text.Json.Serialization;

namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class Rootyamlfile
    {
        [JsonPropertyName("ref")]
        public string _ref { get; set; }
        public string yamlFile { get; set; }
        public string repoAlias { get; set; }
    }
}