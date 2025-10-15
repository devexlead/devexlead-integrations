namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class Queue
    {
        public int id { get; set; }
        public string name { get; set; }
        public Pool pool { get; set; }
    }
}