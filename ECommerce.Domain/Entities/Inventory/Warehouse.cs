using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Inventory;

public class Warehouse : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public ICollection<Stock> Stocks { get; set; } = [];
}
