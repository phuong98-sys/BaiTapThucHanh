using Abp.Authorization;
using Gosei.SimpleTaskApp.Authorization.Roles;
using Gosei.SimpleTaskApp.Authorization.Users;

namespace Gosei.SimpleTaskApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
