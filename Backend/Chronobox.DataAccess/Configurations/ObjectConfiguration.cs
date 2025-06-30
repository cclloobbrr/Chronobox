using Chronobox.Core.Models;
using Chronobox.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronobox.DataAccess.Configurations
{
    public class ObjectConfiguration : IEntityTypeConfiguration<ObjectEntity>
    {
        public void Configure(EntityTypeBuilder<ObjectEntity> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(Container.MAX_NAME_LENGTH);

            builder.Property(o => o.HasExpirationDate)
                .IsRequired();

            builder.Property(o => o.ContainerId)
                .IsRequired();

            builder
                .HasOne(o => o.Expiration)
                .WithOne()
                .HasForeignKey<ExpirationEntity>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder
                .HasOne(o => o.Container)
                .WithMany(c => c.Objects)
                .HasForeignKey(c => c.ContainerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
