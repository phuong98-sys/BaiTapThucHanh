using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Gosei.SimpleTaskApp.Configuration;
using Gosei.SimpleTaskApp.Web;

namespace Gosei.SimpleTaskApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SimpleTaskAppDbContextFactory : IDesignTimeDbContextFactory<SimpleTaskAppDbContext>
    {
        public SimpleTaskAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SimpleTaskAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SimpleTaskAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SimpleTaskAppConsts.ConnectionStringName));

            return new SimpleTaskAppDbContext(builder.Options);
        }
    }
}
