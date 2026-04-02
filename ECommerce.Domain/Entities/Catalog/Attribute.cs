using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Catalog;

public class Attribute : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<AttributeValue> Values { get; set; } = [];
}
