using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Order;

public class ShipmentSnapshot : BaseEntity
{
    public Guid OrderId { get; set; }

    public string Address { get; set; } = string.Empty;

    public string Carrier { get; set; } = string.Empty;

    public string? TrackingNumber { get; set; }

    public Order Order { get; set; } = null!;
}
