using System.Text.Json.Serialization;

namespace DevEx.Integrations.JIRA.Model
{
    public class JiraUser
    {
        [JsonPropertyName("displayname")]
        public string DisplayName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }
    }
}