using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Catalog;

namespace ECommerce.Domain.Entities.Inventory;

public class Stock : BaseEntity
{
    public Guid VariantId { get; set; }

    public Guid WarehouseId { get; set; }

    public int Quantity { get; set; }

    public int ReservedQuantity { get; set; }

    public Variant Variant { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;
}
