using System.Text;
using DevExLead.Integrations.AzureDevOps.Model;
using Refit;

namespace DevExLead.Integrations.Confluence
{
    /// <summary>
    /// https://docs.atlassian.com/confluence/REST/latest/
    /// </summary>
    public class AzureDevOpsConnector
    {
        Dictionary<string, string> _headers;
        IAzureDevOps _api;
        string _organization;
        string _project;

        public AzureDevOpsConnector(string organization, string project, string personalAccessToken, bool isVerbose)
        {
            var baseUrl = "https://dev.azure.com";
            _organization = organization;
            _project = project;

            var pat = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalAccessToken}"));

            _headers = new Dictionary<string, string> {
                                                            { "Authorization", $"Basic {pat}"}
                                                      };

            var settings = RefitHelper.GetSettings(isVerbose);
            _api = RestService.For<IAzureDevOps>(baseUrl, settings);
        }

        public async Task<List<AzureDevOpsPipeline>> FetchPipelines()
        {
            var result = await _api.FetchPipelines(_headers, _organization, _project);
            return result.value.ToList();
        }

        public async Task<List<AzureDevOpsBuild>> FetchBuilds(int buildId, string branch, string statusFilter)
        {
            var result = await _api.FetchBuilds(_headers, _organization, _project, buildId, branch, statusFilter);
            return result.value.OrderByDescending(b => b.queueTime).ToList();
        }


        public async Task<List<AzureDevOpsBuild>> RunBuild(int pipelineId, int runId, string branch, string commitId, List<string> stagesToSkip)
        {
            var azureDevOpsRunBody = new AzureDevOpsRunBody
            {
                 previewRun=false,
                 resources = new Resources
                  {
                      pipelines = new Pipelines
                      {
                          self = new PipelinesSelf()
                          {
                              runId = runId
                          }
                      },
                      repositories = new Repositories
                      {
                          self = new RepositoriesSelf()
                          {
                              refName = branch,
                              version = commitId
                          }
                      }
                 },
                stagesToSkip = stagesToSkip.ToArray()
            };  

            var result = await _api.RunBuild(_headers, _organization, _project, pipelineId, azureDevOpsRunBody);
            return result.value.OrderByDescending(b => b.queueTime).ToList();
        }


        public async Task<List<AzureDevOpsRun>> FetchRuns(int pipelineId)
        {
            var result = await _api.FetchRuns(_headers, _organization, _project, pipelineId);
            return result.value.OrderByDescending(b => b.createdDate).ToList();
        }


    }
}
