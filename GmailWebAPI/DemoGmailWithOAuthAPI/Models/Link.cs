using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoGmailWithOAuthAPI.Models
{
    public class Link
    {
        public string @rel { get; set; }
        public string @href { get; set; }
        public string @type { get; set; }
    }
}