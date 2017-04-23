using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestApp.Entities
{
    public class TestAppDbContext : IdentityDbContext<User>
    {
        public TestAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DataEntity> DataEntities { get; set; }
    }
}
