using System.Collections.Generic;
using Practice.Roles.Dto;

namespace Practice.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
