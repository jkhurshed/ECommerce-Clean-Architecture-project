using ECommerce.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Slug).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.HasIndex(x => x.Slug).IsUnique();
    }
}
