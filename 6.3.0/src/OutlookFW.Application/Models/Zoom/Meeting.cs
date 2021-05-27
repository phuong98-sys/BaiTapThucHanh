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
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
    }
}
