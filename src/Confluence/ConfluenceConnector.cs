using System.Text;
using DevEx.Integrations.Confluence.Model;
using Refit;

namespace DevEx.Integrations.Confluence
{
    /// <summary>
    /// https://docs.atlassian.com/confluence/REST/latest/
    /// </summary>
    public class ConfluenceConnector
    {
        Dictionary<string, string> _headers;
        IConfluenceAPI _api;

        public ConfluenceConnector(string baseUrl, string user, string key)
        {
            var atlassianAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{key}"));
            
            _headers = new Dictionary<string, string> {
                                                            { "Authorization", $"Basic {atlassianAuth}"} 
                                                      };

            var settings = RefitHelper.GetSettings();
            _api = RestService.For<IConfluenceAPI>(baseUrl, settings);
        }

        public async Task UpdatePageAsync(string pageId, string htmlContent, string comment)
        {
            //Get ConfluenceConnector Page Info
            var wikiPage = await _api.GetPageAsync(_headers, pageId);

            //Update ConfluenceConnector Page
            var requestBody = new ConfluencePageUpdateRequest()
            {
                Type = "page",
                Title = wikiPage.Title,
                Body = new ConfluencePageBody()
                {
                    Storage = new ConfluencePageBodyStorage()
                    {
                        Value = htmlContent,
                        Representation = "storage"
                    }
                },
                Version = new ConfluencePageVersion()
                {
                    Number = wikiPage.Version.Number + 1,
                    Message = comment
                }
            };

            var result = await _api.UpdatePageAsync(_headers, pageId, requestBody);
        }

        public async Task<List<ConfluencePageSearchResult>> SearchContentByUserAsync(string userAccountId)
        {
            var pageResults = await _api.SearchAsync(_headers, userAccountId);
            return pageResults.Results; 
        }
    }
}
