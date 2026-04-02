using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Catalog;

public class AttributeValue : BaseEntity
{
    public Guid AttributeId { get; set; }

    public Guid VariantId { get; set; }

    public string Value { get; set; } = string.Empty;

    public Attribute Attribute { get; set; } = null!;
    public Variant Variant { get; set; } = null!;
}
