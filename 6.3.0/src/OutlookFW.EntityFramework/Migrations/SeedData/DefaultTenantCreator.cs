using System.Linq;
using OutlookFW.EntityFramework;
using OutlookFW.MultiTenancy;

namespace OutlookFW.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly OutlookFWDbContext _context;

        public DefaultTenantCreator(OutlookFWDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
