using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TestAngular.Authorization.Roles;
using TestAngular.Authorization.Users;
using TestAngular.MultiTenancy;
using Acme.SimpleTaskApp.Tasks;
using TestAngular.Tasks.Configuration;

namespace TestAngular.EntityFrameworkCore
{
    public class TestAngularDbContext : AbpZeroDbContext<Tenant, Role, User, TestAngularDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Task> Tasks { get; set; }
        public TestAngularDbContext(DbContextOptions<TestAngularDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TaskEntityConfiguration.Configure(modelBuilder.Entity<Task>());
        }
    }
}
