using System.Text;
using DevEx.Integrations.JIRA.Model;
using DevEx.Integrations.JIRA.Model.Request;
using DevEx.Integrations.JIRA.Model.Response;
using Refit;

namespace DevEx.Integrations.JIRA
{
    /// <summary>
    /// https://docs.atlassian.com/confluence/REST/latest/
    /// </summary>
    public class JiraConnector
    {
        Dictionary<string, string> _headers;
        IJiraAPI _api;

        public JiraConnector(string baseUrl, string user, string key)
        {
            var atlassianAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{key}"));

            _headers = new Dictionary<string, string> {
                                                            { "Authorization", $"Basic {atlassianAuth}" }
                                                      };

            var settings = RefitHelper.GetSettings();
            _api = RestService.For<IJiraAPI>(baseUrl, settings);
        }

        public async Task<JiraIssueQueryResponse> RunJqlAsync(string jql, int startAt)
        {
            var response = await _api.RunJqlAsync(_headers, $"{jql}", startAt);
            return response;
        }

        public async Task<JiraIssueCreateResponse> CreateIssueAsync(JiraIssueCreateRequest jiraIssueCreateRequest)
        {
            var jiraResponse = await _api.CreateIssueAsync(_headers, jiraIssueCreateRequest);
            return jiraResponse;
        }

        public async Task<JiraSprintQueryResponse> FetchSprints(int boardId, int startAt)
        {
            var response = await _api.FetchSprints(_headers, boardId, startAt);
            return response;
        }


        public Task<List<JiraRelease>> FetchFixVersions(string projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<JiraCommentResponse> FetchComments(string issueId)
        {
            return await _api.FetchComments(_headers, issueId);
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
