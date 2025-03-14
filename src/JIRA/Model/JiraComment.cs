using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model
{
    public class JiraComment
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
