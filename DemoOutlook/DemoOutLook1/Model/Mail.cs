using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoOutLook1.Model
{
    public class Mail
    {
        public string name { get; set; }
        public string subject { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string date { get; set; }
        public string body { get; set; }
    }
}