using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestAngular.Configuration;

namespace TestAngular.Web.Host.Startup
{
    [DependsOn(
       typeof(TestAngularWebCoreModule))]
    public class TestAngularWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TestAngularWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestAngularWebHostModule).GetAssembly());
        }
    }
}
