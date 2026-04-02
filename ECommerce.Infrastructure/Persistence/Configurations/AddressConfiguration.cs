using ECommerce.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.Country).IsRequired().HasMaxLength(100);
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Street).IsRequired().HasMaxLength(200);
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(20);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
