using DevExLead.Integrations.GoogleCalendar.Model.Response;
using Refit;

namespace DevExLead.Integrations
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IGoogleCalendar
    {
        [Get("/calendar/v3/calendars/{calendarId}.official%23holiday%40group.v.calendar.google.com/events?key={apiKey}")]
        Task<GoogleCalendarResponse> GetPublicHolidays([AliasAs("calendarId")] string calendarId, string apiKey);
    }
}