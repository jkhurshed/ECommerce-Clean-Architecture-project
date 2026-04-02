using ECommerce.Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CartId).IsRequired();
        builder.Property(x => x.VariantId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitPrice).HasPrecision(18, 2);

        builder.HasOne(x => x.Cart)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
