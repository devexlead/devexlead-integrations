using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model.Request
{
    public class JqlRequest
    {
        [JsonPropertyName("jql")]
        public string Jql { get; set; }

        [JsonPropertyName("startAt")]
        public int StartAt { get; set; }

        [JsonPropertyName("maxResults")]
        public int MaxResults { get; set; }

        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }

        [JsonPropertyName("expand")]
        public string[] Expand { get; set; }
    }

}
