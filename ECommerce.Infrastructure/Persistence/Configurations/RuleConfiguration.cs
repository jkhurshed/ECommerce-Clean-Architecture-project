using ECommerce.Domain.Entities.Promotion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class RuleConfiguration : IEntityTypeConfiguration<Rule>
{
    public void Configure(EntityTypeBuilder<Rule> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.DiscountId).IsRequired();
        builder.Property(x => x.Condition).IsRequired().HasMaxLength(2000);
        builder.Property(x => x.Action).IsRequired().HasMaxLength(2000);

        builder.HasOne(x => x.Discount)
            .WithMany(x => x.Rules)
            .HasForeignKey(x => x.DiscountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
