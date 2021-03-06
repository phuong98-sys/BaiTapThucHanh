﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using OutlookFW.Configuration.Dto;

namespace OutlookFW.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : OutlookFWAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
