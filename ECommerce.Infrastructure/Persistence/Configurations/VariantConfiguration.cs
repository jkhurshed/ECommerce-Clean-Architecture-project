using ECommerce.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class VariantConfiguration : IEntityTypeConfiguration<Variant>
{
    public void Configure(EntityTypeBuilder<Variant> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.SKU).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Price).HasPrecision(18, 2);
        builder.Property(x => x.CompareAtPrice).HasPrecision(18, 2);
        builder.HasIndex(x => x.SKU).IsUnique();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Variants)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
