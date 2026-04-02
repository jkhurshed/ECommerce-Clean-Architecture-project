using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Catalog;

public class Media : BaseEntity
{
    public Guid ProductId { get; set; }

    public string Url { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public Product Product { get; set; } = null!;
}
