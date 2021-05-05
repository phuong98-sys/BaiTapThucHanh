using System;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;

namespace GmailWebAPI.MVC4
{
    public class AppFlowMetadata : FlowMetadata
    {
        public static Object user;
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "369518912260-5g5delg9bh600r6amuqsvmc0n995f2b7.apps.googleusercontent.com",
                    ClientSecret = "XA4yC-8Oj6pMWhdJS5CS7ZZH",
                   

                },
                Scopes = new[] { "https://mail.google.com/" },
                DataStore = new FileDataStore("Google.Apis.Gmail.v1")
               
            });

        public override string GetUserId(Controller controller)
        {
           
             user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
           
                controller.Session["user"] = user;
            }
            return user.ToString();

        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}
