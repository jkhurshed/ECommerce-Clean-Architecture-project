using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Catalog;

public class Brand : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}
