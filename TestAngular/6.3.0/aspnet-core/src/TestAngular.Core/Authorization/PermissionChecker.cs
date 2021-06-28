using Abp.Authorization;
using TestAngular.Authorization.Roles;
using TestAngular.Authorization.Users;

namespace TestAngular.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
