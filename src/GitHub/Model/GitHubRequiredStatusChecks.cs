using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  DevEx.Integrations.GitHub.Model
{

    public class GitHubRequiredStatusChecks
    {
        public string enforcement_level { get; set; }
        public object[] contexts { get; set; }
        public object[] checks { get; set; }
    }

}
