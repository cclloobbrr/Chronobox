using Chronobox.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chronobox.DataAccess
{
    public class ChronoboxDbContext : DbContext
    {
        public ChronoboxDbContext(DbContextOptions<ChronoboxDbContext> options) : base(options)
        {
        }

        public DbSet<ContainerEntity> Containers { get; set; }
        public DbSet<ObjectEntity> Object { get; set; }
        public DbSet<ExpirationEntity> Expiration { get; set; }

    }
}
