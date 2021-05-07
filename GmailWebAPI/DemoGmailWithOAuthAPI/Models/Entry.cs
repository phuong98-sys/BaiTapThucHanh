using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoGmailWithOAuthAPI.Models
{
    public class Entry
    {
        public string title { get; set; }
        public string summary { get; set; }
        public Link2 link { get; set; }
        public DateTime modified { get; set; }
        public DateTime issued { get; set; }
        public string id { get; set; }
        public Author author { get; set; }

    }
}