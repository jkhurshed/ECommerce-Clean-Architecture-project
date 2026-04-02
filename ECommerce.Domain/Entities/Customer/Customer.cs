using ECommerce.Domain.Common;
using CartEntity = ECommerce.Domain.Entities.Cart.Cart;
using OrderEntity = ECommerce.Domain.Entities.Order.Order;

namespace ECommerce.Domain.Entities.Customer;

public class Customer : BaseEntity
{
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ICollection<Address> Addresses { get; set; } = [];

    public Preferences? Preferences { get; set; }

    public ICollection<CartEntity> Carts { get; set; } = [];

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
