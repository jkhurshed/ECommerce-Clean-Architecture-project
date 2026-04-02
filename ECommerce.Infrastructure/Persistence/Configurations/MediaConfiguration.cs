using ECommerce.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
        builder.Property(x => x.SortOrder).IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Media)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
