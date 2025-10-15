namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class Yamldetails
    {
        public Includedtemplate[] includedTemplates { get; set; }
        public Rootyamlfile rootYamlFile { get; set; }
        public string expandedYamlUrl { get; set; }
    }
}