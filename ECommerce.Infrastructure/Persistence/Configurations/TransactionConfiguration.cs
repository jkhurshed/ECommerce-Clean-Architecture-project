using ECommerce.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(x => x.Currency).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Provider).IsRequired().HasMaxLength(100);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
