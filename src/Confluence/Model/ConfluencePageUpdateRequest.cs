using Integrations.Confluence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engmgr.Integrations.Confluence.Model
{
    public class ConfluencePageUpdateRequest
    {
        public string Type { get; set; } = "page";
        public string Title { get; set; }
        public ConfluencePageBody Body { get; set; }
        public ConfluencePageVersion Version { get; set; }
    }
}
