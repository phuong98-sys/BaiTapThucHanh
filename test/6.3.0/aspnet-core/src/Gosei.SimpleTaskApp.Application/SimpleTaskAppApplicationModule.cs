﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Gosei.SimpleTaskApp.Authorization;

namespace Gosei.SimpleTaskApp
{
    [DependsOn(
        typeof(SimpleTaskAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SimpleTaskAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SimpleTaskAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SimpleTaskAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}
