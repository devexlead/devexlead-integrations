namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsPipelinesResponse
    {
        public int count { get; set; }
        public AzureDevOpsPipeline[] value { get; set; }
    }
}
