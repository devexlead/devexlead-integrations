using System.Text.Json.Serialization;
using Integrations.JIRA.Model;

namespace engmgr.Core.Integrations.JIRA.Model.Request
{
    public class JiraIssueCreateRequest
    {
        [JsonPropertyName("fields")]
        public JiraFieldsCreateRequest Fields { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("changelog")]
        public JiraChangelog Changelog { get; set; }

    }
}