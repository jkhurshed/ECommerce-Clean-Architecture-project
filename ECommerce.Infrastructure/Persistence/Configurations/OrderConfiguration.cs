using ECommerce.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.TotalAmount).HasPrecision(18, 2);
        builder.Property(x => x.Currency).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.HasIndex(x => x.OrderNumber).IsUnique();

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
