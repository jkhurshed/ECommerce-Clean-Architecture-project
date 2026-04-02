using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Customer;

public class Address : BaseEntity
{
    public Guid CustomerId { get; set; }

    public string Country { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public bool IsDefault { get; set; }

    public Customer Customer { get; set; } = null!;
}
