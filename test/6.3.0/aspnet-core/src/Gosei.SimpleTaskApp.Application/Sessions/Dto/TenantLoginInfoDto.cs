using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Gosei.SimpleTaskApp.MultiTenancy;

namespace Gosei.SimpleTaskApp.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
