using ECommerce.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.VariantId).IsRequired();
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.UnitPrice).HasPrecision(18, 2);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.TotalPrice).HasPrecision(18, 2);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
