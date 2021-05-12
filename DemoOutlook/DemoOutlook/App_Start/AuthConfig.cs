using DotNetOpenAuth.AspNet.Clients;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoOutlook.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            if (OpenAuth.AuthenticationClients.GetByProviderName("microsoft") == null)
            {
                MicrosoftClient msClient = new MicrosoftClient("a8f83bd5-dd71-4f7b-a56b-295a5a1a0334", ".Xm4NgH873~rGMoMvCz.21pNsSEp0~.QnD");
                OpenAuth.AuthenticationClients.Add("microsoft", () => msClient);
            }
        }
    }
}