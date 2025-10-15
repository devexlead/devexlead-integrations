namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsBuildBuildsResponse
    {
        public int count { get; set; }
        public AzureDevOpsBuild[] value { get; set; }
    }
}