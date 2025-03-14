using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model
{
    public class JiraFixVersion
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}