using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class AttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
