using System.Text.Json.Serialization;

namespace  DevEx.Integrations.JIRA.Model
{
    public class JiraComment
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
