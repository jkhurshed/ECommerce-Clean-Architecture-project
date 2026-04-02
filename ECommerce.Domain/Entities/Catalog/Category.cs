using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Catalog;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }

    public bool IsActive { get; set; }

    public Category? Parent { get; set; }

    public ICollection<Category> Children { get; set; } = [];

    public ICollection<Product> Products { get; set; } = [];
}
