using DevExLead.Integrations.AzureDevOps.Model;
using DevExLead.Integrations.JIRA.Model.Request;
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

        [Get("/{organization}/{project}/_apis/build/builds?definitions={buildId}&branchName={branchName}&statusFilter={statusFilter}&api-version=7.1-preview.7")]
        Task<AzureDevOpsBuildBuildsResponse> FetchBuilds([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("project")] string project, [AliasAs("buildId")] int buildId, [AliasAs("branchName")] string branchName, [AliasAs("statusFilter")] string statusFilter);

        [Get("/{organization}/{project}/_apis/pipelines/{pipelineId}/runs?api-version=7.2-preview.1")]
        Task<AzureDevOpsRunsResponse> FetchRuns([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("project")] string project, [AliasAs("pipelineId")] int pipelineId);

        [Get("/{organization}/{project}/_apis/pipelines/{pipelineId}/runs/{runId}?api-version=7.1-preview.1")]
        Task<AzureDevOpsRun> FetchRun([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("project")] string project, [AliasAs("pipelineId")] int pipelineId, [AliasAs("runId")] int runId);

        [Post("/{organization}/{project}/_apis/pipelines/{pipelineId}/runs?api-version=7.1-preview.1")]
        Task<AzureDevOpsBuildBuildsResponse> RunBuild([HeaderCollection] IDictionary<string, string> headers, [AliasAs("organization")] string organization, [AliasAs("project")] string project, [AliasAs("pipelineId")] int pipelineId, [Body] AzureDevOpsRunBody azureDevOpsRunBody);
        



        /*
         
         Step 1: Find pending approvals for a run. You can query checks for resources (the environment, run, etc.).

Query checks (approvals) for a run: POST https://dev.azure.com/{organization}/{project}/_apis/pipelines/checks/query?api-version=7.1-preview.1 Body example: { "resources": [ { "type": "pipelineRun", "id": "<runId>", "name": "", "repository": "", "ref": "" } ] }

Response returns a list; approvals appear with type “Approval” including an approvalId (sometimes nested as id). You might also query by environment resource: { "resources":[ { "type":"environment", "id":"<environmentId>" } ] }

Step 2: Approve a specific approval: PATCH https://dev.azure.com/{organization}/{project}/_apis/pipelines/checks/approvals/{approvalId}?api-version=7.1-preview.1 Body: { "status": "Approved", "comment": "Approved via API" }

Curl: curl -X PATCH
-H "Content-Type: application/json"
-H "Authorization: Basic $AUTH"
-d '{"status":"Approved","comment":"Approved via API"}'
https://dev.azure.com/myorg/myproject/_apis/pipelines/checks/approvals/7777?api-version=7.1-preview.1

Possible statuses: Approved, Rejected, Canceled (depending on state).
         
         */
    }
}