using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Models.Zoom
{
    public class Meeting
    {
        public string Topic { get; set; }
        public string Agenda { get; set; }
        public DateTime start_time { get; set; }
        public string join_url { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
    }
}
