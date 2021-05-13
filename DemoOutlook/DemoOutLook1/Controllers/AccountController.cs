using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DemoOutLook1.TokenStorage;
using System.Linq;
using DemoOutLook1.Helpers;
using System.Configuration;

namespace DemoOutLook1.Controllers
{
    public class AccountController : Controller
    {
        private static string appId = ConfigurationManager.AppSettings["ida:AppId"];
        private static string graphScopes = ConfigurationManager.AppSettings["ida:AppScopes"];
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                // Signal OWIN to send an authorization request to Azure
                Request.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
        
        //private static GraphServiceClient graphClient;
        //public static void Initialize(IAuthenticationProvider authProvider)
        //{
        //    var authProvider = new DemoOutLook1.App.DeviceCodeAuthProvider(appId, scopes);
        //    graphClient = new GraphServiceClient(authProvider);
        //}
        //public static async Task<User> GetMeAsync()
        //{
        //    try
        //    {
        //        // GET /me
        //        return await graphClient.Me.Request().GetAsync();
        //    }
        //    catch (ServiceException ex)
        //    {
        //      //  Console.WriteLine($"Error getting signed-in user: {ex.Message}");
        //        return null;
        //    }
        //}
        public async Task SendEmail()
        {
            //var authProvider = new DemoOutLook1.Startup.DeviceCodeAuthProvider(appId, graphScopes);
            //GraphHelper.Initialize(authProvider);

            //var message = new Message
            //{
            //    Subject = "Your subject here",
            //    Body = new ItemBody
            //    {
            //        ContentType = BodyType.Html,
            //        Content = "Email Content"
            //    },
            //    ToRecipients = new List<Recipient>()
            //    {
            //        new Recipient
            //        {
            //            EmailAddress = new EmailAddress
            //            {
            //                Address = "phuongred98@gmail.com"
            //            }
            //        }
            //    },
            //    CcRecipients = new List<Recipient>()
            //    {
            //        new Recipient
            //        {
            //            EmailAddress = new EmailAddress
            //            {
            //                Address = "phuongred98@gmail.com"
            //            }
            //        }
            //    }
            //};
            //var token = DemoOutLook1.Startup.accessToken;
            //// Build the Microsoft Graph client. As the authentication provider, set an async lambda
            //// which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            //// and inserts this access token in the Authorization header of each API request. 
            //GraphServiceClient graphServiceClient =
            //    new GraphServiceClient(new DelegateAuthenticationProvider(async (requestMessage) =>
            //    {
            //        // Add the access token in the Authorization header of the API request.
            //        requestMessage.Headers.Authorization =
            //                new AuthenticationHeaderValue("Bearer", token);
            //    })
            //    );


            //await graphServiceClient.Users["phuongred98@gmail.com"]
            //      .SendMail(message, false)
            //      .Request()
            //      .PostAsync();
            //return View();


        }
        public ActionResult SignOut()
        {
            //FormsAuthentication.SignOut();

            //return Redirect(Url.Action("Index", "Home"));
            //if (Request.IsAuthenticated)
            //{
            //    Request.GetOwinContext().Authentication.SignOut(
            //        CookieAuthenticationDefaults.AuthenticationType);
            //}

            //return RedirectToAction("Index", "Home");
            if (Request.IsAuthenticated)
            {
                var tokenStore = new SessionTokenStore(null,
                    System.Web.HttpContext.Current, ClaimsPrincipal.Current);

                tokenStore.Clear();

                Request.GetOwinContext().Authentication.SignOut(
                    CookieAuthenticationDefaults.AuthenticationType);
            }

            return RedirectToAction("Index", "Home");
        }
      
    }
}