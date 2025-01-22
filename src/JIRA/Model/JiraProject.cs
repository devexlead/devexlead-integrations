using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model
{
    public class JiraProject
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}