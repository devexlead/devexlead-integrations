using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model.Response
{

    public class JiraIssueCreateResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
