namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsRun
    {
        public Yamldetails yamlDetails { get; set; }
        public _Links _links { get; set; }
        public Templateparameters templateParameters { get; set; }
        public Pipeline pipeline { get; set; }
        public string state { get; set; }
        public string result { get; set; }
        public DateTime createdDate { get; set; }
        public string url { get; set; }
        public Resources resources { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}