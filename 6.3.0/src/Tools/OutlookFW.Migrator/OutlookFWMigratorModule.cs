using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using OutlookFW.EntityFramework;

namespace OutlookFW.Migrator
{
    [DependsOn(typeof(OutlookFWDataModule))]
    public class OutlookFWMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<OutlookFWDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}