using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model
{
    public class JiraPriority
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}