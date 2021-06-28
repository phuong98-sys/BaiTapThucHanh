using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TestAngular.Configuration;
using TestAngular.Web;

namespace TestAngular.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TestAngularDbContextFactory : IDesignTimeDbContextFactory<TestAngularDbContext>
    {
        public TestAngularDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestAngularDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TestAngularDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TestAngularConsts.ConnectionStringName));

            return new TestAngularDbContext(builder.Options);
        }
    }
}
