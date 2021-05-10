using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoOutlookOAuthAPI.Models
{
    public class Entry

    {
    
        public Author author { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public DateTime modified { get; set; }
        public DateTime issued { get; set; }
        public string id { get; set; }

    }
}