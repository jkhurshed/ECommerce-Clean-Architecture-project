using ECommerce.Domain.Common;
using OrderEntity = ECommerce.Domain.Entities.Order.Order;

namespace ECommerce.Domain.Entities.Payment;

public class Transaction : BaseEntity
{
    public Guid OrderId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Provider { get; set; } = string.Empty;

    public OrderEntity Order { get; set; } = null!;

    public ICollection<Refund> Refunds { get; set; } = [];
}
