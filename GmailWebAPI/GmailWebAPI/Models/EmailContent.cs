using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GmailWebAPI.Models
{
    public class EmailContent
    {
        public string from { get; set; }
    
        public string date { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
    }
}