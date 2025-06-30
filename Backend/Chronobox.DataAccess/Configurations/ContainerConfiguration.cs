using Chronobox.Core.Models;
using Chronobox.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronobox.DataAccess.Configurations
{
    public class ContainerConfiguration : IEntityTypeConfiguration<ContainerEntity>
    {
        public void Configure(EntityTypeBuilder<ContainerEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(Container.MAX_NAME_LENGTH);

            builder.Property(c => c.DateOfCreation)
                .IsRequired();

            builder
                .HasMany(c => c.Objects)
                .WithOne(o => o.Container)
                .HasForeignKey(o => o.ContainerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
