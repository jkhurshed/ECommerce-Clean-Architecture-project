using ECommerce.Domain.Common;
using OrderEntity = ECommerce.Domain.Entities.Order.Order;

namespace ECommerce.Domain.Entities.Shipping;

public class Shipment : BaseEntity
{
    public Guid OrderId { get; set; }

    public string Status { get; set; } = string.Empty;

    public string? TrackingNumber { get; set; }

    public OrderEntity Order { get; set; } = null!;
}
