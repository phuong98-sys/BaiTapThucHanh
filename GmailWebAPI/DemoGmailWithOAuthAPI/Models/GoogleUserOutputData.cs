﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoGmailWithOAuthAPI.Models
{
    public class GoogleUserOutputData

    {

        public string id { get; set; }

        public string name { get; set; }

        public string given_name { get; set; }

        public string email { get; set; }
        public string password { get; set; }

        public string picture { get; set; }

    }
}