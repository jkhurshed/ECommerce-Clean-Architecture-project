using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Catalog;
using CartEntity = ECommerce.Domain.Entities.Cart.Cart;
using OrderEntity = ECommerce.Domain.Entities.Order.Order;

namespace ECommerce.Domain.Entities.Inventory;

public class Reservation : BaseEntity
{
    public Guid VariantId { get; set; }

    public int Quantity { get; set; }

    public DateTime ExpiresAt { get; set; }

    public Guid? CartId { get; set; }
    public Guid? OrderId { get; set; }

    public Variant Variant { get; set; } = null!;
    public CartEntity? Cart { get; set; }
    public OrderEntity? Order { get; set; }
}
