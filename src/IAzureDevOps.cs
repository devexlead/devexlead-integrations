using DevExLead.Integrations.AzureDevOps.Model;
using Refit;

namespace DevExLead.Integrations
{
    /// <summary>
    /// https://docs.github.com/en/rest
    /// </summary>
    public interface IAzureDevOps
    {
        [Get("/{organization}/{project}/_apis/pipelines?api-version=7.1-preview.1")]
        Task<AzureDevOpsPipelinesResponse> FetchPipelines([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("project")] string project);

    }
}