using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Shipping;

public class CarrierMethod : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int EstimatedDays { get; set; }
}
