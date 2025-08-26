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

        public async Task<AzureDevOpsPipelinesResponse> FetchPipelines()
        {
            var result = await _api.FetchPipelines(_headers, _organization, _project);
            return result;
        }


    }
}
