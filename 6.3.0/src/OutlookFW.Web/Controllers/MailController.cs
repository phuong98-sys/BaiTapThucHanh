using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
//using DemoOutLook1.TokenStorage;
using System.Linq;
//using DemoOutLook1.Helpers;
using System.Configuration;
using OutlookFW.Mails;
using OutlookFW.Web.Models.Outlooks;
using OutlookFW.Web.TokenStorage;
//using DemoOutLook1.Model;
namespace OutlookFW.Web.Controllers
{
    
    public class MailController : OutlookFWControllerBase
    {
        // GET: Mail
        public static IMailAppService _mailAppService;
        
        //private readonly ILookupAppService _lookupAppService;
        public MailController(IMailAppService mailAppService)
        {
            _mailAppService = mailAppService;
            //_mailAppService = mailAppService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task SignIn()
        {
            //if (!Request.IsAuthenticated)
            //{
            // Signal OWIN to send an authorization request to Azure
          Request.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
             
            //var userDetails = await _mailAppService.GetUserDetailsAsync(OutlookFW.Web.App_Start.Startup.accessToken1);
            //    return  RedirectToAction("GetMail", "Mail");
            // }
        }
        public async Task<ActionResult> GetMail()
        {
            var listMail = await _mailAppService.GetMailAsync(OutlookFW.Web.App_Start.Startup.accessToken);
            //var model = new IndexViewMail(listMail,"");
            return View(listMail);
        }

     
        //public async Task<ActionResult> SendMail(Mail model)
        //{
        //    try
        //    {
        //        await GraphHelper.SendMailAsync(DemoOutLook1.Startup.accessToken1, model.subject, model.to, model.body);

        //    }
        //    catch (ServiceException ex)
        //    {

        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        public ActionResult SignOut()
        {

            //if (OutlookFW.Web.App_Start.Startup.email!=null)
            //{
            //    var tokenStore = new SessionTokenStore(null,
            //        System.Web.HttpContext.Current, ClaimsPrincipal.Current);

            //    tokenStore.Clear();

            //    Request.GetOwinContext().Authentication.SignOut(
            //        CookieAuthenticationDefaults.AuthenticationType);
            //}


            Request.GetOwinContext().Authentication.SignOut();
            OutlookFW.Web.App_Start.Startup.email = null;
            return RedirectToAction("Index", "Home");



        }
    }
}