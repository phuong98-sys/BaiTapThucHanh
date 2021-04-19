using System.Collections.Generic;
using Practice.Roles.Dto;

namespace Practice.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}