using System.Collections.Generic;
using Gosei.SimpleTaskApp.Roles.Dto;

namespace Gosei.SimpleTaskApp.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
