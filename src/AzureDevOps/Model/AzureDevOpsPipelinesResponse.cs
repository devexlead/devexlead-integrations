namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsPipelinesResponse
    {
        public int count { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
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

}
