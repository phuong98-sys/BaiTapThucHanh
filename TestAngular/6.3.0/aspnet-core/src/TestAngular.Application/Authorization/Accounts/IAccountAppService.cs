using System.Threading.Tasks;
using Abp.Application.Services;
using TestAngular.Authorization.Accounts.Dto;

namespace TestAngular.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
