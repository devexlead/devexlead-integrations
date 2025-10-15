namespace DevExLead.Integrations.GitHub.Model
{
    public class Verification
    {
        public bool verified { get; set; }
        public string reason { get; set; }
        public string signature { get; set; }
        public string payload { get; set; }
        public DateTime? verified_at { get; set; }
    }

}
