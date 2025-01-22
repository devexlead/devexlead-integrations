using System.Text.Json.Serialization;
using Integrations.JIRA.Model;

namespace engmgr.Core.Integrations.JIRA.Model.Request
{
    public class JiraFieldsCreateRequest
    {

        [JsonPropertyName("project")]
        public JiraProject Project { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("parent")]
        public JiraParent Parent { get; set; }

        [JsonPropertyName("components")]
        public List<JiraComponent> Components { get; set; }


        [JsonPropertyName("issuetype")]
        public JiraIssueType IssueType { get; set; }

        [JsonPropertyName("assignee")]
        public JiraAssignee Assignee { get; set; }

        [JsonPropertyName("priority")]
        public JiraPriority Priority { get; set; }

        //TODO: Make this customizable
        [JsonPropertyName("customfield_10020")]
        public int? SprintId { get; set; }


        [JsonPropertyName("fixVersions")]
        public List<JiraFixVersion> FixVersions { get; set; }

        [JsonPropertyName("customfield_10045")]
        public JiraEnvironment Environment { get; set; }
        [JsonPropertyName("duedate")]
        public virtual DateOnly? DueDate { get; set; }

        [JsonPropertyName("timeestimate")]
        public int? TimeEstimateInSeconds { get; set; }

    }
}