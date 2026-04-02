using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Inventory;
using ECommerce.Domain.Entities.Payment;
using ECommerce.Domain.Entities.Shipping;
using CustomerEntity = ECommerce.Domain.Entities.Customer.Customer;

namespace ECommerce.Domain.Entities.Order;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;

    public Guid CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public CustomerEntity Customer { get; set; } = null!;

    public ICollection<OrderItem> Items { get; set; } = [];

    public PaymentSnapshot? Payment { get; set; }
    public ShipmentSnapshot? Shipment { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = [];

    public ICollection<Reservation> Reservations { get; set; } = [];

    public ICollection<Shipment> Shipments { get; set; } = [];
}
