using ECommerce.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.VariantId).IsRequired();
        builder.Property(x => x.WarehouseId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.ReservedQuantity).IsRequired();
        builder.HasIndex(x => new { x.VariantId, x.WarehouseId }).IsUnique();

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
