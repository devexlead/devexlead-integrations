using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model.Response
{
    public class JiraIssueQueryResponse
    {
        [JsonPropertyName("startat")]
        public int StartAt { get; set; }

        [JsonPropertyName("maxresults")]
        public int MaxResults { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("issues")]
        public List<JiraIssue> Issues { get; set; }
    }
}