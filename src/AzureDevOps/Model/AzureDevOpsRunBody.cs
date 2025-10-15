namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsRunBody
    {
        public bool previewRun { get; set; }
        public string[] stagesToSkip { get; set; }
        public Resources resources { get; set; }
    }


}
