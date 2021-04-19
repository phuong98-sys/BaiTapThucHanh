using System.Collections.Generic;
using Practice.Roles.Dto;

namespace Practice.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
