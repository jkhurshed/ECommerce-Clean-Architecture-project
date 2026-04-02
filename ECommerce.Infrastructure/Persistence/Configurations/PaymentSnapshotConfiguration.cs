using ECommerce.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class PaymentSnapshotConfiguration : IEntityTypeConfiguration<PaymentSnapshot>
{
    public void Configure(EntityTypeBuilder<PaymentSnapshot> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.Method).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.HasIndex(x => x.OrderId).IsUnique();

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Payment)
            .HasForeignKey<PaymentSnapshot>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
