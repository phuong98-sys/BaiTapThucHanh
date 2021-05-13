using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DemoOutLook1.Startup))]

namespace DemoOutLook1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}