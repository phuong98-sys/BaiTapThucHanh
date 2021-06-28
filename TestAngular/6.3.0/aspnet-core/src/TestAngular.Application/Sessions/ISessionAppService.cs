using System.Threading.Tasks;
using Abp.Application.Services;
using TestAngular.Sessions.Dto;

namespace TestAngular.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
