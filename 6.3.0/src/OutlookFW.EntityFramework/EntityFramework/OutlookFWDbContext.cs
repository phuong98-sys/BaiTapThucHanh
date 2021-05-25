using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using OutlookFW.Authorization.Roles;
using OutlookFW.Authorization.Users;
using OutlookFW.Mails;
using OutlookFW.MultiTenancy;
using OutlookFW.Senders;

namespace OutlookFW.EntityFramework
{
    public class OutlookFWDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Token> Tokens { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public OutlookFWDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in OutlookFWDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of OutlookFWDbContext since ABP automatically handles it.
         */
        public OutlookFWDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public OutlookFWDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public OutlookFWDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
