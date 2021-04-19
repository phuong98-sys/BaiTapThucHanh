using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Practice.Authorization.Roles;
using Practice.Authorization.Users;
using Practice.MultiTenancy;
using Practice.Tasks;
using Practice.Persons;

namespace Practice.EntityFrameworkCore
{
    public class PracticeDbContext : AbpZeroDbContext<Tenant, Role, User, PracticeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Person> People { get; set; }
        public PracticeDbContext(DbContextOptions<PracticeDbContext> options)
            : base(options)
        {
        }
    }
}
