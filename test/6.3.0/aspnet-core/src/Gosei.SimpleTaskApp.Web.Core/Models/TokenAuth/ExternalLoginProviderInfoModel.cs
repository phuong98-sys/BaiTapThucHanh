using Abp.AutoMapper;
using Gosei.SimpleTaskApp.Authentication.External;

namespace Gosei.SimpleTaskApp.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
