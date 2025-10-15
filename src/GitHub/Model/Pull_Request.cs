namespace DevExLead.Integrations.GitHub.Model
{
    public class Pull_Request
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string diff_url { get; set; }
        public string patch_url { get; set; }
        public object merged_at { get; set; }
    }
}
