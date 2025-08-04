using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model
{
    public class JiraHistory
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("author")]
        public JiraUser Author { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("items")]
        public JiraItem[] Items { get; set; }
    }
}