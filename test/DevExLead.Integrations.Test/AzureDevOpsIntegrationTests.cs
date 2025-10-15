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
            var pipelines = await _connector.FetchPipelines();
            var pipeline = pipelines.FirstOrDefault(p => p.name.Equals("client-release"));
            //statusFilter = notStarted,completed,inProgress,cancelling,postponed,all
            var builds = await _connector.FetchBuilds(pipeline.id, "refs/heads/main", "inProgress,completed");
            var stagesToSkip = new List<string> { "Docker_Build", "Stage_Release" };
            var runs = await _connector.FetchRuns(pipeline.id);
            foreach (var run in runs)
            {
                var runDetails = await _connector.FetchRun(pipeline.id, run.id);
                var build = builds.FirstOrDefault(b => b.buildNumber == run.name);
                Console.WriteLine($"{run.id} - {run.state} - {build.triggerInfo.cimessage} - {build.triggerInfo.cisourceBranch} - {build.triggerInfo.cisourceSha}");
                await _connector.RunBuild(pipeline.id, run.id, build.triggerInfo.cisourceBranch, build.triggerInfo.cisourceSha, stagesToSkip);
            }
        }

    }
}
