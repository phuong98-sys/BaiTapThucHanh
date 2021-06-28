using System.Threading.Tasks;
using TestAngular.Models.TokenAuth;
using TestAngular.Web.Controllers;
using Shouldly;
using Xunit;

namespace TestAngular.Web.Tests.Controllers
{
    public class HomeController_Tests: TestAngularWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}