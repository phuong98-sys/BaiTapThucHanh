using System.Threading.Tasks;
using Abp.Application.Services;
using OutlookFW.Sessions.Dto;

namespace OutlookFW.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
