using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Practice.Configuration;
using Practice.Web;

namespace Practice.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PracticeDbContextFactory : IDesignTimeDbContextFactory<PracticeDbContext>
    {
        public PracticeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PracticeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PracticeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PracticeConsts.ConnectionStringName));

            return new PracticeDbContext(builder.Options);
        }
    }
}
