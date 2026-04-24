using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Identity;
using CartEntity = ECommerce.Domain.Entities.Cart.Cart;
using OrderEntity = ECommerce.Domain.Entities.Order.Order;

namespace ECommerce.Domain.Entities.Customer;

public class Customer : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string? Phone { get; set; }

    public ICollection<Address> Addresses { get; set; } = [];

    public Preferences? Preferences { get; set; }

    public ICollection<CartEntity> Carts { get; set; } = [];

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
