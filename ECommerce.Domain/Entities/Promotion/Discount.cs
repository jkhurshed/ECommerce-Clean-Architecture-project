using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Promotion;

public class Discount : BaseEntity
{
    public decimal Value { get; set; }

    public string Type { get; set; } = string.Empty;

    public Guid? CouponId { get; set; }

    public Coupon? Coupon { get; set; }

    public ICollection<Rule> Rules { get; set; } = [];
}
