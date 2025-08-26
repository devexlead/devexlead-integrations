using DevExLead.Integrations.Confluence;
using Microsoft.Extensions.Configuration;

namespace DevExLead.Integrations.Test
{
    public class AzureDevOpsIntegrationTests
    {
        IConfigurationRoot _configuration;
        AzureDevOpsConnector _connector;

        public AzureDevOpsIntegrationTests()
        {
            _configuration = new ConfigurationBuilder()
               .AddUserSecrets<AzureDevOpsIntegrationTests>()
               .Build();

            string organization = _configuration["AzureDevOps:Organization"];
            string project = _configuration["AzureDevOps:Project"];
            string personalAccessToken = _configuration["AzureDevOps:PersonalAccessToken"];
            _connector = new AzureDevOpsConnector(organization, project, personalAccessToken, true);
        }

        [Fact]
        public async Task FetchPipelines()
        {
            var response = await _connector.FetchPipelines();
        }

    }
}
