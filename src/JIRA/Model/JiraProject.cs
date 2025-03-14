using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model
{
    public class JiraProject
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}