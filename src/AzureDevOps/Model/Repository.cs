namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class Repository
    {
        public string fullName { get; set; }
        public Connection connection { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public object clean { get; set; }
        public bool checkoutSubmodules { get; set; }
    }
}