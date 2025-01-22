using System.Text.Json.Serialization;

namespace Integrations.JIRA.Model
{
    public class JiraAssignee
    {
        [JsonPropertyName("displayname")]
        public string DisplayName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }
    }
}