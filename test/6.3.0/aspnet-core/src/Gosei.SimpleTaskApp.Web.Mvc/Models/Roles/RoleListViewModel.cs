using System.Collections.Generic;
using Gosei.SimpleTaskApp.Roles.Dto;

namespace Gosei.SimpleTaskApp.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
