using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Promotion;

public class Coupon : BaseEntity
{
    public string Code { get; set; } = string.Empty;

    public decimal? DiscountValue { get; set; }

    public string DiscountType { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public ICollection<Discount> Discounts { get; set; } = [];
}
