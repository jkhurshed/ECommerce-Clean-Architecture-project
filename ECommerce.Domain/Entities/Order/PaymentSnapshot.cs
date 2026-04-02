using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Order;

public class PaymentSnapshot : BaseEntity
{
    public Guid OrderId { get; set; }

    public string Method { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Status { get; set; } = string.Empty;

    public Order Order { get; set; } = null!;
}
