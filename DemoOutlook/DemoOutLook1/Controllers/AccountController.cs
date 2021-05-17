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
using DemoOutLook1.Model;

namespace DemoOutLook1.Controllers
{
    public class AccountController : Controller
    {
       
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
        public async Task<ActionResult> GetMail()
        {
            var listMail = await GraphHelper.GetMeAsync(DemoOutLook1.Startup.accessToken1);
            return View(listMail);
        }
        public async Task<ActionResult> SendMail(Mail model)
        {
            try
            {
                await GraphHelper.SendMailAsync(DemoOutLook1.Startup.accessToken1,model.subject, model.to, model.body);
               
            }
            catch(ServiceException ex)
            {
                
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignOut()
        {
           
           
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");


           
        }
      
    }
}