using Abp.Authorization;
using OutlookFW.Authorization.Roles;
using OutlookFW.Authorization.Users;

namespace OutlookFW.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
