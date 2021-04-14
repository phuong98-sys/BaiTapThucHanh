using Abp.Application.Services;
using Gosei.SimpleTaskApp.MultiTenancy.Dto;

namespace Gosei.SimpleTaskApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

