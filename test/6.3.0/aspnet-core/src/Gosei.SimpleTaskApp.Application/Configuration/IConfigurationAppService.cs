using System.Threading.Tasks;
using Gosei.SimpleTaskApp.Configuration.Dto;

namespace Gosei.SimpleTaskApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
