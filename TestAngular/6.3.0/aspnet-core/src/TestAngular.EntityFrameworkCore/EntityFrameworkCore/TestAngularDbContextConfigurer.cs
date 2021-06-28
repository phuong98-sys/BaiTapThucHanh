using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TestAngular.EntityFrameworkCore
{
    public static class TestAngularDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TestAngularDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TestAngularDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
