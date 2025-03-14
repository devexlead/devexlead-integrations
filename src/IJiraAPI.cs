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
        [Get("/rest/api/2/search?jql={jql}&expand=changelog&maxResults=100&startAt={startAt}")]
        Task<JiraIssueQueryResponse> RunJqlAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("jql")] string jql, int startAt);

        [Get("/rest/api/2/project/{projectId}/versions")]
        Task<List<JiraRelease>> FetchFixVersions([HeaderCollection] IDictionary<string, string> headers, [AliasAs("projectId")] string projectId);

        [Get("/rest/agile/latest/board/{boardId}/sprint?startAt={startAt}")]
        Task<JiraSprintQueryResponse> FetchSprints([HeaderCollection] IDictionary<string, string> headers, [AliasAs("boardId")] int boardId, [AliasAs("startAt")] int startAt);

        [Get("/rest/api/2/issue/{issueId}/comment")]
        Task<JiraCommentResponse> FetchComments([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId);

        [Get("/rest/api/3/group/member?groupname={GroupName}")]
        Task<JiraGroupMembersResponse> GetJiraUsersByGroupName([HeaderCollection] IDictionary<string, string> headers, [AliasAs("GroupName")] string groupName);

        [Post("/rest/api/2/issue/{issueId}/comment")]
        Task PostComment([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] string request);

        [Post("/rest/api/2/issue")]
        Task<JiraIssueCreateResponse> CreateIssueAsync([HeaderCollection] IDictionary<string, string> headers, [Body] JiraIssueCreateRequest request);

        [Put("/rest/api/3/issue/{issueId}")]
        Task ChangeIssueFieldAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] StringContent request);

        [Post("/rest/api/2/issue/{issueId}/watchers")]
        Task WatchIssueAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("issueId")] string issueId, [Body] string userId);

    }
}