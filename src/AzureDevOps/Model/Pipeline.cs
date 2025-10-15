namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class Pipeline
    {
        public string href { get; set; }
        public string url { get; set; }
        public int id { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public string folder { get; set; }
    }
}