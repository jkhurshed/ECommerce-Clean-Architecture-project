using ECommerce.Domain.Entities.Promotion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.DiscountValue).HasPrecision(18, 2);
        builder.Property(x => x.DiscountType).IsRequired().HasMaxLength(20);
        builder.HasIndex(x => x.Code).IsUnique();
    }
}
