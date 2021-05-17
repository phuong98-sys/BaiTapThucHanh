using System.Threading.Tasks;
using Abp.Application.Services;
using OutlookFW.Configuration.Dto;

namespace OutlookFW.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}