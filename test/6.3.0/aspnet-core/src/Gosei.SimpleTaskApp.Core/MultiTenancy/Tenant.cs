using Abp.MultiTenancy;
using Gosei.SimpleTaskApp.Authorization.Users;

namespace Gosei.SimpleTaskApp.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
