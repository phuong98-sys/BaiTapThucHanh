using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutlookFW.Models.Gmails
{
    public class RequestParameters
    {
        public String scope { get; set; }
        public String access_type { get; set; }
        public String include_granted_scopes { get; set; }
        public String response_type { get; set; }
        public String state { get; set; }
        public String redirect_uri { get; set; }
        public String client_id { get; set; }
        public String code { get; set; }
        public String client_secret { get; set; }
        public String grant_type { get; set; }
    }
}