using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoGmailWithOAuthAPI.Models
{
    public class Root
    {
        public Xml xml { get; set; }
        public Feed feed { get; set; }
    }
}