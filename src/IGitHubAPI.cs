using DevExLead.Integrations.GitHub.Model;
using Refit;

namespace DevExLead.Integrations
{
    /// <summary>
    /// https://docs.github.com/en/rest
    /// </summary>
    public interface IGitHubAPI
    {
        [Get("/repos/{organization}/{repository}/branches/{branchName}")]
        Task<GitHubBranch> GetBranch([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("repository")] string repository, [AliasAs("branchName")] string branchName);

        [Get("/repos/{organization}/{repository}/commits?sha={branchName}&per_page=100")]
        Task<GitHubCommitsResponse> GetCommits([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("repository")] string repository, [AliasAs("branchName")] string branchName);

        [Get("/search/issues?q=org:{organization}+is:pr+in:title,body+{jiraIssueId}")]
        Task<GitHubPullRequests> GetPullRequests([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("jiraIssueId")] string jiraIssueId);

        //[Get("/repos/humanforce/hf-cli/commits?sha=HF-19503&author=leandromonaco")]
        //Task<GitHubPullRequests> GetPullRequestsByUserId([HeaderCollection] IDictionary<string, string> headers);


        //[Post("/graphql")]
        //Task<GraphQLResponse> RunGraphQLQuery([HeaderCollection] IDictionary<string, string> headers, [Body] GitHubGraphQLRequest request);
    }
}