using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Gosei.SimpleTaskApp.Authorization.Roles;
using Gosei.SimpleTaskApp.Authorization.Users;
using Gosei.SimpleTaskApp.MultiTenancy;
using Gosei.SimpleTaskApp.Tasks;

namespace Gosei.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpZeroDbContext<Tenant, Role, User, SimpleTaskAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Task> Tasks { get; set; }
        public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options)
            : base(options)
        {
        }
    }
}
