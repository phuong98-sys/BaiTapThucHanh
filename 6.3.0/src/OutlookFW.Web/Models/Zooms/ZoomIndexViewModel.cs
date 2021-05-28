using OutlookFW.Models.Zoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutlookFW.Web.Models.Zooms
{
    public class ZoomIndexViewModel
    {
        public IReadOnlyList<Meeting> Meetings { get; }
        public string UserEmail { get;  }
        public bool isAuthenticated { get; set; }
        public ZoomIndexViewModel()
        {
            Meetings = null;
            UserEmail = null;
            isAuthenticated = false;
        }
        public ZoomIndexViewModel(IReadOnlyList<Meeting> meetings, string userEmail)
        {
            Meetings = meetings;
            UserEmail = userEmail;
        }
    }
}