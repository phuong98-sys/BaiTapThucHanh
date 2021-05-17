using System.Collections.Generic;
using OutlookFW.Roles.Dto;
using OutlookFW.Users.Dto;

namespace OutlookFW.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}