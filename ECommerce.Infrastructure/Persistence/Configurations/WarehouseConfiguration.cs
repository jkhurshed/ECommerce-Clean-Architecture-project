using ECommerce.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Location).IsRequired().HasMaxLength(250);
    }
}
