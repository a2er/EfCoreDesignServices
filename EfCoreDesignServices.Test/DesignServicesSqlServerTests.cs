using Microsoft.EntityFrameworkCore;

namespace EfCoreDesignServices
{
    internal class DesignServicesSqlServerTests : DesignServicesTestsBase
    {
        protected override void OnBuildOptions(DbContextOptionsBuilder<MyDbContext> builder)
        {
            builder.UseSqlServer("Server=(localdb)\\v11.0;Integrated Security=true;");
        }
    }
}
