using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model
{
    public class JiraIssue
    {
        [JsonPropertyName("fields")]
        public JiraFields Fields { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("changelog")]
        public JiraChangelog Changelog { get; set; }

    }
}