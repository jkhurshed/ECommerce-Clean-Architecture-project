using ECommerce.Domain.Common;
using CustomerEntity = ECommerce.Domain.Entities.Customer.Customer;

namespace ECommerce.Domain.Entities.Cart;

public class Cart : BaseEntity
{
    public Guid? CustomerId { get; set; }

    public CustomerEntity? Customer { get; set; }

    public ICollection<CartItem> Items { get; set; } = [];
}
