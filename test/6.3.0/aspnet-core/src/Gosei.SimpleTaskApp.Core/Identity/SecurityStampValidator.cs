using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Gosei.SimpleTaskApp.Authorization.Roles;
using Gosei.SimpleTaskApp.Authorization.Users;
using Gosei.SimpleTaskApp.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace Gosei.SimpleTaskApp.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
