using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using OutlookFW.EntityFramework;

namespace OutlookFW
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(OutlookFWCoreModule))]
    public class OutlookFWDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<OutlookFWDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
