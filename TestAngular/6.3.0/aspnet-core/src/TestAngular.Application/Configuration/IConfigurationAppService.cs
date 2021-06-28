using System.Threading.Tasks;
using TestAngular.Configuration.Dto;

namespace TestAngular.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
