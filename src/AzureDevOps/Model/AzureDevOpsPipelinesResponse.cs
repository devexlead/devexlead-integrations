namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsPipelinesResponse
    {
        public int count { get; set; }
        public AzureDevOpsPipeline[] value { get; set; }
    }

    public class AzureDevOpsPipeline
    {
        public _Links _links { get; set; }
        public string url { get; set; }
        public int id { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public string folder { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Web web { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }



    public class AzureDevOpsRunBody
    {
        public bool previewRun { get; set; }
        public string[] stagesToSkip { get; set; }
        public Resources resources { get; set; }
    }

    public class Resources
    {
        public Pipelines pipelines { get; set; }
        public Repositories repositories { get; set; }
    }

    public class Pipelines
    {
        public PipelinesSelf self { get; set; }
    }

    public class PipelinesSelf
    {
        public int runId { get; set; }
    }

    public class Repositories
    {
        public RepositoriesSelf self { get; set; }
    }

    public class RepositoriesSelf
    {
        public string refName { get; set; }
        public string version { get; set; }
    }


}
