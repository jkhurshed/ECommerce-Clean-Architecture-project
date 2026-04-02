using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Catalog;

namespace ECommerce.Domain.Entities.Cart;

public class CartItem : BaseEntity
{
    public Guid CartId { get; set; }

    public Guid VariantId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public Cart Cart { get; set; } = null!;
    public Variant Variant { get; set; } = null!;
}
