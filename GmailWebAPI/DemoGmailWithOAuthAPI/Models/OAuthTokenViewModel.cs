using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoGmailWithOAuthAPI.Models
{
    public class OAuthTokenViewModel
    {
        public string Access_token { get; set; }
        public int Expires_in { get; set; }
        public string Scope { get; set; }
        public string Token_type { get; set; }

    }
}