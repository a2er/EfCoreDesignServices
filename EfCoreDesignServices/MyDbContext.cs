using Microsoft.EntityFrameworkCore;

namespace EfCoreDesignServices
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
