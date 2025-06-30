using Chronobox.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronobox.DataAccess.Configurations
{
    public class ExpirationConfiguration : IEntityTypeConfiguration<ExpirationEntity>
    {
        public void Configure(EntityTypeBuilder<ExpirationEntity> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.EndDate)
                .IsRequired();
        }
    }
}
