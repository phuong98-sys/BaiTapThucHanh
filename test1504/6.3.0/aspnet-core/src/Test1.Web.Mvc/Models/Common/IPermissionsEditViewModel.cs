using System.Collections.Generic;
using Test1.Roles.Dto;

namespace Test1.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}