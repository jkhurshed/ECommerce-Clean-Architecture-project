using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Payment;

public class Refund : BaseEntity
{
    public Guid TransactionId { get; set; }

    public decimal Amount { get; set; }

    public string Reason { get; set; } = string.Empty;

    public Transaction Transaction { get; set; } = null!;
}
