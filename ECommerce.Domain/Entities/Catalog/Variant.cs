using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Cart;
using ECommerce.Domain.Entities.Inventory;
using ECommerce.Domain.Entities.Order;

namespace ECommerce.Domain.Entities.Catalog;

public class Variant : BaseEntity
{
    public Guid ProductId { get; set; }

    public string SKU { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal? CompareAtPrice { get; set; }

    public bool IsActive { get; set; }

    public Product Product { get; set; } = null!;

    public ICollection<AttributeValue> Attributes { get; set; } = [];

    public ICollection<CartItem> CartItems { get; set; } = [];

    public ICollection<OrderItem> OrderItems { get; set; } = [];

    public ICollection<Reservation> Reservations { get; set; } = [];

    public ICollection<Stock> Stocks { get; set; } = [];
}
