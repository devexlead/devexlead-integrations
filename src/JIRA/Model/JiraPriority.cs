using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model
{
    public class JiraPriority
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}