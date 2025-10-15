using DevExLead.Integrations.GitHub;
using DevExLead.Integrations.JIRA;
using DevExLead.Integrations.JIRA.Model.Request;
using Microsoft.Extensions.Configuration;

namespace DevExLead.Integrations.Test
{
    public class GitHubIntegrationTests
    {
        IConfigurationRoot _configuration;
        GitHubConnector _githubConnector;

        public GitHubIntegrationTests()
        {
            _configuration = new ConfigurationBuilder()
               .AddUserSecrets<JiraIntegrationTests>()
               .Build();

            string gitHubToken = _configuration["GitHub:Token"];
            _githubConnector = new GitHubConnector(gitHubToken, true);
        }

        [Fact]
        public async Task GetCommits()
        {
            var response = await _githubConnector.GetCommits("owner", "repo", "refs/heads/main");
        }


      
    }
}
