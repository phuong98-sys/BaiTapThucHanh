using Abp.Application.Services;
using TestAngular.MultiTenancy.Dto;

namespace TestAngular.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

