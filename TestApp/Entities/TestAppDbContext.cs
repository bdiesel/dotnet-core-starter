using Microsoft.EntityFrameworkCore;

namespace TestApp.Entities
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DataEntity> DataEntities { get; set; }
    }
}
