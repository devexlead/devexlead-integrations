using System.Text.Json.Serialization;
using Integrations.JIRA.Model;

namespace engmgr.Core.Integrations.JIRA.Model.Response
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
        public List<JiraIssue> Values { get; set; }
    }
}