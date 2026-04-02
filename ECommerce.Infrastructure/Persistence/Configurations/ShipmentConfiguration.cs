using ECommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.Property(x => x.TrackingNumber).HasMaxLength(100);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Shipments)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
