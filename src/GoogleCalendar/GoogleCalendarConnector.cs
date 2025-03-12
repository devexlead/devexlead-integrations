using DevEx.Integrations.GoogleCalendar.Model;
using Refit;

namespace DevEx.Integrations.GoogleCalendar
{
    public class GoogleCalendarConnector
    {
        readonly string _apiKey;
        private IGoogleCalendar _api;

        public GoogleCalendarConnector(string key, bool isVerbose)
        {
            _apiKey = key;
            var settings = RefitHelper.GetSettings(isVerbose);
            _api = RestService.For<IGoogleCalendar>("https://www.googleapis.com", settings);
        }

        public async Task<List<GoogleCalendarEvent>> GetPublicHolidaysAsync(string calendarId)
        {
            var result = await _api.GetPublicHolidays(calendarId, _apiKey);
            var calendar = result.items;
            return calendar;
        }
    }
}