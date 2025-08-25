using DevExLead.Integrations.JIRA;
using DevExLead.Integrations.JIRA.Model.Request;
using Microsoft.Extensions.Configuration;

namespace DevExLead.Integrations.Test
{
    public class JiraIntegrationTests
    {
        IConfigurationRoot _configuration;
        JiraConnector _jiraConnector;

        public JiraIntegrationTests()
        {
            _configuration = new ConfigurationBuilder()
               .AddUserSecrets<JiraIntegrationTests>()
               .Build();

            string jiraUser = _configuration["Atlassian:User"];
            string jiraPassword = _configuration["Atlassian:Password"];
            string jiraBaseUrl = _configuration["Atlassian:BaseUrl"];

            _jiraConnector = new JiraConnector(jiraBaseUrl, jiraUser, jiraPassword, true);
        }

        [Fact]
        public async Task CreateComponentsAsync()
        {
            var componentRequest = new ComponentRequest
            {
                Name = "Test Component",
                Description = "This is a test component",
                Project = "SCN"
            };
            await _jiraConnector.CreateComponentAsync(componentRequest);

        }

        [Fact]
        public async Task CreateSprintsAsync()
        {
            var sprintNumber = 88;
            var startDate = new DateOnly(2025, 10, 16);

            for (int i = 0; i < 10; i++)
            {
                var sprintCreateRequest = new SprintCreateRequest
                {
                    Name = $"Sprint {sprintNumber}",
                    StartDate = startDate,
                    EndDate = startDate.AddDays(13),
                    OriginBoardId = 1697,
                    Goal = "TBD"
                };

                await _jiraConnector.CreateSprintAsync(sprintCreateRequest);

                startDate = sprintCreateRequest.EndDate.AddDays(1);
                sprintNumber++;
            }

        }
    }
}
