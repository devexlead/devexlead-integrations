using DevExLead.Integrations.JIRA.Model;
using DevExLead.Integrations.JIRA.Model.Request;
using DevExLead.Integrations.JIRA.Model.Response;
using devex_integrations.JIRA.Model.Response;
using Refit;
using System.Text;

namespace DevExLead.Integrations.JIRA
{
    /// <summary>
    /// https://docs.atlassian.com/confluence/REST/latest/
    /// </summary>
    public class JiraConnector
    {
        Dictionary<string, string> _headers;
        IJiraAPI _api;

        public JiraConnector(string baseUrl, string user, string key, bool isVerbose)
        {
            var atlassianAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{key}"));

            _headers = new Dictionary<string, string> {
                                                            { "Authorization", $"Basic {atlassianAuth}" }
                                                      };

            var settings = RefitHelper.GetSettings(isVerbose);
            _api = RestService.For<IJiraAPI>(baseUrl, settings);
        }

        public async Task<List<JiraIssue>> RunJqlAsync(string jql)
        {
            var allJiraIssues = new List<JiraIssue>();

            var increment = 100;
            var startAt = 0;
            var finishAt = 1;

            while (startAt <= finishAt)
            {
                var response = await _api.RunJqlAsync(_headers, $"{jql}", startAt);
                startAt += increment;
                finishAt = (int)response.Total - 1;
                allJiraIssues.AddRange(response.Issues);
            }

            return allJiraIssues;
        }

        public async Task<JiraIssueCreateResponse> CreateIssueAsync(JiraIssueCreateRequest jiraIssueCreateRequest)
        {
            var jiraResponse = await _api.CreateIssueAsync(_headers, jiraIssueCreateRequest);
            return jiraResponse;
        }

        public async Task<List<JiraSprint>> FetchSprints(int boardId)
        {
            var allJiraSprints = new List<JiraSprint>();

            var increment = 100;
            var startAt = 0;
            var finishAt = 1;

            while (startAt <= finishAt)
            {
                var response = await _api.FetchSprints(_headers, boardId, startAt);
                startAt += increment;
                finishAt = (int)response.Total - 1;
                allJiraSprints.AddRange(response.Values);
            }

            return allJiraSprints;
        }


        public Task<List<JiraRelease>> FetchFixVersions(string projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<JiraCommentResponse> FetchComments(string issueId)
        {
            return await _api.FetchComments(_headers, issueId);
        }

        public async Task<JiraGroupMembersResponse> GetJiraUsersByGroupName(string groupName)
        {
            return await _api.GetJiraUsersByGroupName(_headers, groupName);
        }

        public async Task PostComment(string issueId, string comment)
        {
            var body = $"{{\"body\":\"{comment}\"}}";
            await _api.PostComment(_headers, issueId, body);
        }

        public async Task ChangeIssueFieldAsync(string issueId, string body)
        {
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            await _api.ChangeIssueFieldAsync(_headers, issueId, request);
        }

        public async Task ChangeIssueFieldListAsync(string issueId, string fieldCollection, string fieldName, string fieldValue)
        {
            var body = @"{
                          ""update"": {
                            ""{fieldCollection}"": [
                              {
                                ""add"": {
                                  ""id"": ""fixVersionId""
                                }
                              }
                            ]
                          }
                        }
                        ";

            var request = new StringContent(body, Encoding.UTF8, "application/json");
            await _api.ChangeIssueFieldAsync(_headers, issueId, request);
        }

        public async Task WatchIssueAsync(string issueId, string userId)
        {
            await _api.WatchIssueAsync(_headers, issueId, userId);
        }


    }
}
