using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model
{
    public class JiraParent
    {
        [JsonPropertyName("fields")]
        public JiraFields Fields { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}