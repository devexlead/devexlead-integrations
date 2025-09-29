using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExLead.Integrations.AzureDevOps.Model
{
    public class AzureDevOpsRunsResponse
    {
        public int count { get; set; }
        public AzureDevOpsRun[] value { get; set; }
    }

    public class AzureDevOpsRun
    {
        public _Links _links { get; set; }
        public Templateparameters templateParameters { get; set; }
        public Pipeline1 pipeline { get; set; }
        public string state { get; set; }
        public string result { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime finishedDate { get; set; }
        public string url { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PipelineWeb
    {
        public string href { get; set; }
    }

    public class Pipeline
    {
        public string href { get; set; }
    }

    public class Templateparameters
    {
    }

    public class Pipeline1
    {
        public string url { get; set; }
        public int id { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public string folder { get; set; }
    }

}
