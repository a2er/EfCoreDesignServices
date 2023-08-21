using Microsoft.EntityFrameworkCore;

namespace EfCoreDesignServices
{
    internal class DesignServicesUseNpgsqlTests : DesignServicesTestsBase
    {
        protected override void OnBuildOptions(DbContextOptionsBuilder<MyDbContext> builder)
        {
            builder.UseNpgsql();
        }
    }
}
