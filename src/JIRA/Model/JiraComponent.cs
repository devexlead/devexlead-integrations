using System.Text.Json.Serialization;

namespace Integrations.JIRA.Model
{
    public class JiraComponent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}