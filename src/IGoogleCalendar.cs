using engmgr.Core.Integrations.GoogleCalendar.Model.Response;
using Refit;

namespace engmgr.Core.Integrations
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IGoogleCalendar
    {
        [Get("/calendar/v3/calendars/{countryCode}%23holiday%40group.v.calendar.google.com/events?key={apiKey}")]
        Task<GoogleCalendarResponse> FetchCountryHolidays([AliasAs("countryCode")] string countryCode, string apiKey);

        [Get("/calendar/v3/calendars/{calendarId}%40group.calendar.google.com/events?key={apiKey}")]
        Task<GoogleCalendarResponse> FetchEvents([AliasAs("calendarId")] string calendarId, string apiKey);

    }
}