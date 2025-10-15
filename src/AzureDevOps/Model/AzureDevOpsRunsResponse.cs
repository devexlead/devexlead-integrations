namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsRunsResponse
    {
        public int count { get; set; }
        public AzureDevOpsRun[] value { get; set; }
    }
}