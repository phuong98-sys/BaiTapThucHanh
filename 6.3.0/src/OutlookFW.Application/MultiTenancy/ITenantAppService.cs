using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OutlookFW.MultiTenancy.Dto;

namespace OutlookFW.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
