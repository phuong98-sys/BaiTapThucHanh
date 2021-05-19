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
            OutlookFW.Web.App_Start.Startup.ConfigureAuth(app);


            //app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);



            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //app.MapSignalR();
    

            //ENABLE TO USE HANGFIRE dashboard (Requires enabling Hangfire in OutlookFWWebModule)
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() } //You can remove this line to disable authorization
            //});
        }
    }
}
