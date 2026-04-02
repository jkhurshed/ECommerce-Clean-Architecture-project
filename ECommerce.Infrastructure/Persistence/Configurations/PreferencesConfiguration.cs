using ECommerce.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class PreferencesConfiguration : IEntityTypeConfiguration<Preferences>
{
    public void Configure(EntityTypeBuilder<Preferences> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.Language).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Currency).IsRequired().HasMaxLength(10);
        builder.HasIndex(x => x.CustomerId).IsUnique();

        builder.HasOne(x => x.Customer)
            .WithOne(x => x.Preferences)
            .HasForeignKey<Preferences>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
