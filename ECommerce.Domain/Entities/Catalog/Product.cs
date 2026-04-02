using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Catalog;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid BrandId { get; set; }

    public Guid CategoryId { get; set; }

    public bool IsActive { get; set; }

    public Brand Brand { get; set; } = null!;
    public Category Category { get; set; } = null!;

    public ICollection<Variant> Variants { get; set; } = [];

    public ICollection<Media> Media { get; set; } = [];
}
