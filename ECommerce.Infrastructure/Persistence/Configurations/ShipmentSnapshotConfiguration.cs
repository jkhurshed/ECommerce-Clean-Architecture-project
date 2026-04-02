using ECommerce.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ShipmentSnapshotConfiguration : IEntityTypeConfiguration<ShipmentSnapshot>
{
    public void Configure(EntityTypeBuilder<ShipmentSnapshot> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Carrier).IsRequired().HasMaxLength(100);
        builder.Property(x => x.TrackingNumber).HasMaxLength(100);
        builder.HasIndex(x => x.OrderId).IsUnique();

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Shipment)
            .HasForeignKey<ShipmentSnapshot>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
