using Microsoft.EntityFrameworkCore;
using Sample.Api.DomainModel;

namespace Sample.Api.DataAccess
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}