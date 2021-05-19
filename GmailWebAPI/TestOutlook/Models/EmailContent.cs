using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOutlook.Models
{
    public class EmailContent
    {
        public string from { get; set; }
        public string to { get; set; }
        public string date { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
        public EmailContent()
        {
            from = "";
            to = "";
            date = "";
            body = "";
            subject = "";
        }
    }
}