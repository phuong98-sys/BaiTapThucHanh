using System.Collections.Generic;
using Test1.Roles.Dto;

namespace Test1.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
