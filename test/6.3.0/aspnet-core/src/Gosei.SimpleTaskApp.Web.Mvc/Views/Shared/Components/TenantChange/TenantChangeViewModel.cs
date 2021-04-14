using Abp.AutoMapper;
using Gosei.SimpleTaskApp.Sessions.Dto;

namespace Gosei.SimpleTaskApp.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
