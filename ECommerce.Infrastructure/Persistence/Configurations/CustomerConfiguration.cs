using ECommerce.Domain.Entities.Customer;
using ECommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasBaseType((Type?)null);
        builder.ConfigureBaseEntity();
        builder.HasOne<User>(x => x.User)
               .WithOne()
               .HasForeignKey<Customer>(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.Phone).HasMaxLength(30);
    }
}
