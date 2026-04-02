using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Promotion;

public class Rule : BaseEntity
{
    public Guid DiscountId { get; set; }

    public string Condition { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public Discount Discount { get; set; } = null!;
}
