using DevEx.Integrations.GoogleCalendar.Model;
using Refit;

namespace DevEx.Integrations.GoogleCalendar
{
    public class GoogleCalendarConnector
    {
        readonly string _apiKey;
        private IGoogleCalendar _api;

        public GoogleCalendarConnector(string key)
        {
            _apiKey = key;
            var settings = RefitHelper.GetSettings();
            _api = RestService.For<IGoogleCalendar>("https://www.googleapis.com", settings);
        }

        public async Task<List<GoogleCalendarEvent>> GetPublicHolidaysAsync(CountryEnum country)
        {
            var result = await _api.FetchCountryHolidays(GetCountryCode(country), _apiKey);
            var calendar = result.items;
            return calendar;
        }

        public async Task<List<GoogleCalendarEvent>> GetCalendarEventsAsync(string calendarId)
        {
            var result = await _api.FetchEvents(calendarId, _apiKey);
            var calendar = result.items;
            return calendar;
        }

        private string GetCountryCode(CountryEnum country)
        {
            switch (country)
            {
                case CountryEnum.Australia:
                    return "en.australian";
                case CountryEnum.Pakistan:
                    return "en.pk";
                case CountryEnum.Philippines:
                    return "en.philippines";
                default:
                    return string.Empty;
            }
        }


        /*
            Here is updated on January 2020 list ISO 3166-2 to google calendar name:
            IMPORTANT! For all not listed countries ISO 3166-2 is used so i.e. for Albania it is al.

        {"au", "australian"},
        {"at", "austrian"},
        {"br", "brazilian"},
        {"bg", "bulgarian"},
        {"ca", "canadian"},
        {"cn", "china"},
        {"hr", "croatian"},
        {"cz", "czech"},
        {"dk", "danish"},
        {"fi", "finnish"},
        {"fr", "french"},
        {"de", "german"},
        {"gr", "greek"},
        {"hk", "hong_kong"},
        {"hu", "hungarian"},
        {"in", "indian"},
        {"id", "indonesian"},
        {"ie", "irish"},
        {"il", "jewish"},
        {"it", "italian"},
        {"jp", "japanese"},
        {"lv", "latvian"},
        {"lt", "lithuanian"},
        {"my", "malaysia"},
        {"mx", "mexican"},
        {"nl", "dutch"},
        {"nz", "new_zealand"},
        {"no", "norwegian"},
        {"ph", "philippines"},
        {"pl", "polish"},
        {"pt", "portuguese"},
        {"ro", "romanian"},
        {"ru", "russian"},
        {"sa", "saudiarabian"},
        {"sg", "singapore"},
        {"sk", "slovak"},
        {"si", "slovenian"},
        {"kr", "south_korea"},
        {"es", "spain"},
        {"se", "swedish"},
        {"tw", "taiwan"},
        {"tl", "thai"},
        {"tr", "turkish"},
        {"ua", "ukrainian"},
        {"us", "usa"},
        {"vn", "vietnamese"}

         
         */
    }
}