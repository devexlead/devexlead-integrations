using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model
{
    public class JiraTeam
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}