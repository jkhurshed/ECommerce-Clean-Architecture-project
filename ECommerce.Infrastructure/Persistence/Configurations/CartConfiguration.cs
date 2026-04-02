using ECommerce.Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Carts)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
