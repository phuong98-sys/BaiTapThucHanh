using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Gosei.SimpleTaskApp.Configuration;
using Gosei.SimpleTaskApp.EntityFrameworkCore;
using Gosei.SimpleTaskApp.Migrator.DependencyInjection;

namespace Gosei.SimpleTaskApp.Migrator
{
    [DependsOn(typeof(SimpleTaskAppEntityFrameworkModule))]
    public class SimpleTaskAppMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleTaskAppMigratorModule(SimpleTaskAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(SimpleTaskAppMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                SimpleTaskAppConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
