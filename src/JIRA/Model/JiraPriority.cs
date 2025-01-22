using System.Text.Json.Serialization;

namespace Integrations.JIRA.Model
{
    public class JiraPriority
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}