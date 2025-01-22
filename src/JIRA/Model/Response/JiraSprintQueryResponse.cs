using System.Text.Json.Serialization;
using Integrations.JIRA.Model;

namespace engmgr.Core.Integrations.JIRA.Model.Response
{
    public class JiraSprintQueryResponse
    {
        [JsonPropertyName("startat")]
        public int StartAt { get; set; }

        [JsonPropertyName("maxresults")]
        public int MaxResults { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("values")]
        public List<JiraSprint> Values { get; set; }
    }
}