using ECommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class CarrierMethodConfiguration : IEntityTypeConfiguration<CarrierMethod>
{
    public void Configure(EntityTypeBuilder<CarrierMethod> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Price).HasPrecision(18, 2);
        builder.Property(x => x.EstimatedDays).IsRequired();
    }
}
