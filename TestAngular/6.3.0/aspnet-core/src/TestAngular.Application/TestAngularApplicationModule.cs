using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestAngular.Authorization;

namespace TestAngular
{
    [DependsOn(
        typeof(TestAngularCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestAngularApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TestAngularAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TestAngularApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
            //Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}
