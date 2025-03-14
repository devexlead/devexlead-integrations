using DevExLead.Integrations.Confluence.Model;
using Refit;

namespace DevExLead.Integrations
{
    /// <summary>
    /// https://docs.atlassian.com/confluence/REST/latest/
    /// </summary>
    internal interface IConfluenceAPI
    {
        [Get("/wiki/rest/api/content/search?limit=10000&cql=type=page%20and%20(creator='{userAccountId}' OR contributor='{userAccountId}')&expand=history,history.lastUpdated")]
        Task<ConfluencePageSearchResults> SearchAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("userAccountId")] string userAccountId);

        [Get("/wiki/rest/api/content/{pageId}")]
        Task<ConfluencePage> GetPageAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("pageId")] string pageId);

        [Put("/wiki/rest/api/content/{pageId}")]
        Task<ConfluencePage> UpdatePageAsync([HeaderCollection] IDictionary<string, string> headers, [AliasAs("pageId")] string pageId, [Body] ConfluencePageUpdateRequest request);
    }
}