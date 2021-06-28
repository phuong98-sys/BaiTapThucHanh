using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TestAngular.Configuration.Dto;

namespace TestAngular.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TestAngularAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
