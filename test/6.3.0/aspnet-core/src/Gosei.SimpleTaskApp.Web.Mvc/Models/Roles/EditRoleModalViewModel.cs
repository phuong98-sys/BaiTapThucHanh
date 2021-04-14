using Abp.AutoMapper;
using Gosei.SimpleTaskApp.Roles.Dto;
using Gosei.SimpleTaskApp.Web.Models.Common;

namespace Gosei.SimpleTaskApp.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
