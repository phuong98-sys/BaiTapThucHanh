﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Gosei.SimpleTaskApp.Configuration;

namespace Gosei.SimpleTaskApp.Web.Host.Startup
{
    [DependsOn(
       typeof(SimpleTaskAppWebCoreModule))]
    public class SimpleTaskAppWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleTaskAppWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppWebHostModule).GetAssembly());
        }
    }
}
