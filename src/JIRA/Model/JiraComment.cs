using System.Text.Json.Serialization;

namespace engmgr.Core.Integrations.JIRA.Model
{
    public class JiraComment
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
