using System.Collections.Generic;

namespace Gosei.SimpleTaskApp.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
