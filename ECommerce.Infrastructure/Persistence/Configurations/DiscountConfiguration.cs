using ECommerce.Domain.Entities.Promotion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.Value).HasPrecision(18, 2);
        builder.Property(x => x.Type).IsRequired().HasMaxLength(20);

        builder.HasOne(x => x.Coupon)
            .WithMany(x => x.Discounts)
            .HasForeignKey(x => x.CouponId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
