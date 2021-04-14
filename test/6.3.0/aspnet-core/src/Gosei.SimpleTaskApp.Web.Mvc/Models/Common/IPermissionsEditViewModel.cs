using System.Collections.Generic;
using Gosei.SimpleTaskApp.Roles.Dto;

namespace Gosei.SimpleTaskApp.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}