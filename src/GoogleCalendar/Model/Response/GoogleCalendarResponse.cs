using Integrations.GoogleCalendar.Model;

namespace engmgr.Core.Integrations.GoogleCalendar.Model.Response
{
    public class GoogleCalendarResponse
    {
        public string summary { get; set; }
        public string timeZone { get; set; }
        public DateTime updated { get; set; }
        public List<GoogleCalendarEvent> items { get; set; }

    }
}
