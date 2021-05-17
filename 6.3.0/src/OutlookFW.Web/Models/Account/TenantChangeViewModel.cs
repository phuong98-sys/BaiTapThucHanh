using Abp.AutoMapper;
using OutlookFW.Sessions.Dto;

namespace OutlookFW.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}