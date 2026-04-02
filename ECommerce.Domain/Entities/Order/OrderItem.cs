using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Catalog;

namespace ECommerce.Domain.Entities.Order;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }

    public Guid VariantId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public Order Order { get; set; } = null!;
    public Variant Variant { get; set; } = null!;
}
