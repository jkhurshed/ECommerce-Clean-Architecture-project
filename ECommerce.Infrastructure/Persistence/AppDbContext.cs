using ECommerce.Domain.Entities.Cart;
using ECommerce.Domain.Entities.Catalog;
using ECommerce.Domain.Entities.Customer;
using ECommerce.Domain.Entities.Inventory;
using ECommerce.Domain.Entities.Order;
using ECommerce.Domain.Entities.Payment;
using ECommerce.Domain.Entities.Promotion;
using ECommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using ProductAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<ProductAttribute> Attributes => Set<ProductAttribute>();
    public DbSet<AttributeValue> AttributeValues => Set<AttributeValue>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Variant> Variants => Set<Variant>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Preferences> Preferences => Set<Preferences>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<PaymentSnapshot> PaymentSnapshots => Set<PaymentSnapshot>();
    public DbSet<ShipmentSnapshot> ShipmentSnapshots => Set<ShipmentSnapshot>();
    public DbSet<Refund> Refunds => Set<Refund>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<Discount> Discounts => Set<Discount>();
    public DbSet<Rule> Rules => Set<Rule>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<CarrierMethod> CarrierMethods => Set<CarrierMethod>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
