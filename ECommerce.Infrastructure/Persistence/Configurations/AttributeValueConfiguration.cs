using ECommerce.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
{
    public void Configure(EntityTypeBuilder<AttributeValue> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.AttributeId).IsRequired();
        builder.Property(x => x.VariantId).IsRequired();
        builder.Property(x => x.Value).IsRequired().HasMaxLength(100);

        builder.HasOne(x => x.Attribute)
            .WithMany(x => x.Values)
            .HasForeignKey(x => x.AttributeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.Attributes)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.AttributeId, x.VariantId, x.Value }).IsUnique();
    }
}
