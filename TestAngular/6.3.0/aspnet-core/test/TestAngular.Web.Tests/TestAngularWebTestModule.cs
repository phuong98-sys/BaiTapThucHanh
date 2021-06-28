using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestAngular.EntityFrameworkCore;
using TestAngular.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TestAngular.Web.Tests
{
    [DependsOn(
        typeof(TestAngularWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TestAngularWebTestModule : AbpModule
    {
        public TestAngularWebTestModule(TestAngularEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestAngularWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TestAngularWebMvcModule).Assembly);
        }
    }
}