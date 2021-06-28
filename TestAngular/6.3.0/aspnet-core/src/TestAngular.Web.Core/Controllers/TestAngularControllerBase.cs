using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TestAngular.Controllers
{
    public abstract class TestAngularControllerBase: AbpController
    {
        protected TestAngularControllerBase()
        {
            LocalizationSourceName = TestAngularConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
