using DemoOutlook.Models;
using DotNetOpenAuth.AspNet.Clients;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoOutlook.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult RedirectToMicrosoft()
        {
            string provider = "microsoft";
            string returnUrl = "";
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }, Request.Url.Scheme));
        }
        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OpenAuth.AuthenticationClients.GetByProviderName(Provider).RequestAuthentication(new HttpContextWrapper(System.Web.HttpContext.Current), new Uri(ReturnUrl));
            }
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            if (ProviderName == null || ProviderName == "")
            {
                NameValueCollection nvs = Request.QueryString;
                if (nvs.Count > 0)
                {
                    if (nvs["state"] != null)
                    {
                        NameValueCollection provideritem = HttpUtility.ParseQueryString(nvs["state"]);
                        if (provideritem["microsoft"] != null)
                        {
                            ProviderName = provideritem["microsoft"];
                        }
                    }
                }
            }

            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }, this.Request.Url.Scheme);
            if (ProviderName == null)
            {
                ProviderName = "microsoft";
            }

            MicrosoftClient msClient = OpenAuth.AuthenticationClients.GetByProviderName(ProviderName) as MicrosoftClient;
            var authResult = msClient.VerifyAuthentication(new HttpContextWrapper(HttpContext.ApplicationInstance.Context), new Uri(redirectUrl));

            if (!authResult.IsSuccessful)
            {
                return Redirect(Url.Action("Login", "Account"));
            }

            // User has logged in with provider successfully
            // Check if user is already registered locally
            if (OpenAuth.Login(authResult.Provider, authResult.ProviderUserId, createPersistentCookie: false))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            //Get provider user details
            string ProviderUserId = authResult.ProviderUserId;
            string ProviderUserName = authResult.UserName;
            string FirstName = null;
            string LastName = null;

            string Email = null;
            if (FirstName == null && authResult.ExtraData.ContainsKey("firstname"))
            {
                FirstName = authResult.ExtraData["firstname"];
            }
            if (LastName == null && authResult.ExtraData.ContainsKey("lastname"))
            {
                LastName = authResult.ExtraData["lastname"];
            }
            // call extension method to get email
            ExtendedMicrosoftClientUserData data = msClient.GetExtraData(authResult.ExtraData["accesstoken"]);
            Email = data.Emails.Preferred;

            if (User.Identity.IsAuthenticated)
            {
                // User is already authenticated, add the external login and redirect to return url
                OpenAuth.AddAccountToExistingUser(ProviderName, ProviderUserId, ProviderUserName, User.Identity.Name);
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                // User is new, save email as username
                string membershipUserName = Email ?? ProviderUserId;
                var createResult = OpenAuth.CreateUser(ProviderName, ProviderUserId, ProviderUserName, membershipUserName);

                if (!createResult.IsSuccessful)
                {
                    ViewBag.Message = "User cannot be created";
                    return View();
                }
                else
                {
                    // User created
                    if (OpenAuth.Login(ProviderName, ProviderUserId, createPersistentCookie: false))
                    {
                        return Redirect(Url.Action("Index", "Home"));
                    }
                }
            }
            return View();
        }
        
    }
}