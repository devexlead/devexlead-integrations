using System.Text.Json.Serialization;

namespace Integrations.JIRA.Model
{
    public class JiraStatus
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}