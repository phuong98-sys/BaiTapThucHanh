using System.Collections.Generic;
using Test1.Roles.Dto;

namespace Test1.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
