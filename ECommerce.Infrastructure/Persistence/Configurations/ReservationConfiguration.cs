using ECommerce.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.VariantId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Cart)
            .WithMany()
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
