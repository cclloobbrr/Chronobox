using Untitled.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Untitled.DataAccess
{
    public class UntitledDbContext : DbContext
    {
        public UntitledDbContext(DbContextOptions<UntitledDbContext> options) : base(options)
        {
        }

        public DbSet<ContainerEntity> Containers { get; set; }
        public DbSet<ObjectEntity> Object { get; set; }
        public DbSet<ExpirationEntity> Expiration { get; set; }

    }
}
