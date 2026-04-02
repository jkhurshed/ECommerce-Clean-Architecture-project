using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Customer;

public class Preferences : BaseEntity
{
    public Guid CustomerId { get; set; }

    public string Language { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public bool ReceiveEmails { get; set; }

    public Customer Customer { get; set; } = null!;
}
