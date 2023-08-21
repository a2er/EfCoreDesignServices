using Microsoft.EntityFrameworkCore;

namespace EfCoreDesignServices
{
    internal class DesignServicesSqliteTests : DesignServicesTestsBase
    {
        protected override void OnBuildOptions(DbContextOptionsBuilder<MyDbContext> builder)
        {
            builder.UseSqlite("Data Source=:memory:");
        }
    }
}
