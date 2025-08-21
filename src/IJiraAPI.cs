using DevExLead.Integrations.JIRA.Model;
using DevExLead.Integrations.JIRA.Model.Request;
using DevExLead.Integrations.JIRA.Model.Response;
using Refit;

namespace DevExLead.Integrations
{
    /// <summary>
    /// https://developer.atlassian.com/server/jira/platform/rest/v10000/intro/#gettingstarted
    /// </summary>
    internal interface IJiraAPI
    {
        [Post("/rest/api/3/search")]
        Task<JiraIssueQueryResponse> RunJqlAsync([HeaderCollection] IDictionary<string, string> headers, [Body] JqlRequest request);

        [Get("/rest/api/3/project/{projectId}/versions")]
        Task<List<JiraRelease>> FetchFixVersionsAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("projectId")] string projectId);

        [Get("/rest/agile/latest/board/{boardId}/sprint?startAt={startAt}")]
        Task<JiraSprintQueryResponse> FetchSprintsAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("boardId")] int boardId, [AliasAs("startAt")] int startAt);

        [Get("/rest/api/3/issue/{issueId}/comment")]
        Task<JiraCommentResponse> FetchCommentsAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId);

        [Get("/rest/api/3/group/member?groupname={GroupName}")]
        Task<JiraGroupMembersResponse> GetJiraUsersByGroupNameAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("GroupName")] string groupName);

        [Post("/rest/api/3/issue/{issueId}/comment")]
        Task PostCommentAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] string request);

        [Post("/rest/api/3/issue")]
        Task<JiraIssueCreateResponse> CreateIssueAsync([HeaderCollection] IDictionary<string, string> headers, [Body] JiraIssueCreateRequest request);

        [Put("/rest/api/3/issue/{issueId}/assignee")]
        Task<JiraIssueCreateResponse> UpdateIssueAssigneeAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] JiraUser jiraUser);

        [Put("/rest/api/3/issue/{issueId}")]
        Task ChangeIssueFieldAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] StringContent request);

        [Post("/rest/api/3/issue/{issueId}/watchers")]
        Task WatchIssueWithAccountIdAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] string accountId);

        [Post("/rest/api/3/component")]
        Task<ComponentResponse> CreateComponentAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] ComponentRequest componentRequest);
        
        [Put("/rest/api/3/component/{componentId}")]
        Task<ComponentResponse> UpdateComponentAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("componentId")] string componentId, [Body] ComponentRequest componentRequest);

        [Put("/rest/api/3/project/{projectId}/components")]
        Task<List<ComponentResponse>> FetchAllComponentsAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("projectId")] string projectId);
    }
}
