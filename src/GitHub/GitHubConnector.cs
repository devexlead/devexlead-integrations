using DevExLead.Integrations.GitHub.Model;
using Refit;

namespace DevExLead.Integrations.GitHub
{
    public class GitHubConnector
    {
        IGitHubAPI _api;
        Dictionary<string, string> _headers;

        public GitHubConnector(string token, bool isVerbose)
        {
            _headers = new Dictionary<string, string> {
                                                            { "Authorization", $"Bearer {token}" },
                                                            { "User-Agent", $"EngMgrCli" } //https://docs.github.com/en/rest/overview/resources-in-the-rest-api#user-agent-required
                                                      };

            var settings = RefitHelper.GetSettings(isVerbose);
            _api = RestService.For<IGitHubAPI>("https://api.github.com", settings);
        }

        public async Task<GitHubBranch> GetBranch(string organization, string repository, string jiraIssueId)
        {
            var branch = await _api.GetBranch(_headers, organization, repository, jiraIssueId);
            return branch;
        }

        public async Task<List<GitHubCommit>> GetCommits(string organization, string repository, string branchName)
        {
            var commits = await _api.GetCommits(_headers, organization, repository, branchName);
            return commits;
        }

        public async Task<List<GitHubPullRequest>> GetPullRequests(string organization, string jiraIssueId)
        {
            var pullRequests = await _api.GetPullRequests(_headers, organization, jiraIssueId);
            return pullRequests.items.ToList();
        }
    }
}