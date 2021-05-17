using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using OutlookFW.Web.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class OutlookFWControllerBase : AbpController
    {
        protected OutlookFWControllerBase()
        {
            LocalizationSourceName = OutlookFWConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        protected void Flash(string message, string debug = null)
        {
            var alerts = TempData.ContainsKey(Alert.AlertKey) ?
                (List<Alert>)TempData[Alert.AlertKey] :
                new List<Alert>();

            alerts.Add(new Alert
            {
                Message = message,
                Debug = debug
            });

            TempData[Alert.AlertKey] = alerts;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.IsAuthenticated)
            {
                // Get the user's token cache
                //var tokenStore = new SessionTokenStore(null,
                //    System.Web.HttpContext.Current, ClaimsPrincipal.Current);

                //if (tokenStore.HasData())
                //{
                //    // Add the user to the view bag
                //    ViewBag.User = tokenStore.GetUserDetails();
                //}
                //else
                //{
                //    // The session has lost data. This happens often
                //    // when debugging. Log out so the user can log back in
                //    Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
                //    filterContext.Result = RedirectToAction("Index", "Home");
                //}
            }

            base.OnActionExecuting(filterContext);
        }
    }
}