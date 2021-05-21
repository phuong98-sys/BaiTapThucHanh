using System;
using System.Configuration;
using Abp.Owin;
using OutlookFW.Api.Controllers;
using OutlookFW.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(OutlookFW.Web.Startup))]

namespace OutlookFW.Web
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            // OutlookFW.Web.App_Start.Startup.ConfigureAuth(app);
            //OutlookFW.Web.App_Start.Startup.ConfigureAuth(app);


            //app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);



            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //app.MapSignalR();


            //ENABLE TO USE HANGFIRE dashboard (Requires enabling Hangfire in OutlookFWWebModule)
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() } //You can remove this line to disable authorization
            //});

            app.UseAbp();
              app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);
            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                // by setting following values, the auth cookie will expire after the configured amount of time (default 14 days) when user set the (IsPermanent == true) on the login
                ExpireTimeSpan = new TimeSpan(int.Parse(ConfigurationManager.AppSettings["AuthSession.ExpireTimeInDays.WhenPersistent"] ?? "14"), 0, 0, 0),
                SlidingExpiration = bool.Parse(ConfigurationManager.AppSettings["AuthSession.SlidingExpirationEnabled"] ?? bool.FalseString)

            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();
        }
    }
}
