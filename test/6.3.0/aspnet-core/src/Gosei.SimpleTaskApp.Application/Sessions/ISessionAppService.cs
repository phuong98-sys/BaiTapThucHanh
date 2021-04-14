using System.Threading.Tasks;
using Abp.Application.Services;
using Gosei.SimpleTaskApp.Sessions.Dto;

namespace Gosei.SimpleTaskApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
