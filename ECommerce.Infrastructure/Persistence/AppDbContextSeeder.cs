using ECommerce.Domain.Entities.Cart;
using ECommerce.Domain.Entities.Catalog;
using ECommerce.Domain.Entities.Customer;
using ECommerce.Domain.Entities.Identity;
using ECommerce.Domain.Entities.Inventory;
using ECommerce.Domain.Entities.Order;
using ECommerce.Domain.Entities.Payment;
using ECommerce.Domain.Entities.Promotion;
using ECommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using ProductAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.Infrastructure.Persistence;

public static class AppDbContextSeeder
{
    public static async Task SeedAsync(AppDbContext context, CancellationToken cancellationToken = default)
    {
        await context.Database.MigrateAsync(cancellationToken);

        if (await context.Customers.AnyAsync(cancellationToken))
        {
            return;
        }

        const int recordCount = 20;
        var now = DateTime.UtcNow;

        var brandIds = CreateIds(recordCount, 100);
        var categoryIds = CreateIds(recordCount, 200);
        var productIds = CreateIds(recordCount, 300);
        var variantIds = CreateIds(recordCount, 400);
        var attributeIds = CreateIds(recordCount, 500);
        var attributeValueIds = CreateIds(recordCount, 600);
        var mediaIds = CreateIds(recordCount, 700);
        var userIds = CreateIds(recordCount, 50);
        var customerIds = CreateIds(recordCount, 800);
        var addressIds = CreateIds(recordCount, 900);
        var preferenceIds = CreateIds(recordCount, 1000);
        var cartIds = CreateIds(recordCount, 1100);
        var cartItemIds = CreateIds(recordCount, 1200);
        var warehouseIds = CreateIds(recordCount, 1300);
        var stockIds = CreateIds(recordCount, 1400);
        var couponIds = CreateIds(recordCount, 1500);
        var discountIds = CreateIds(recordCount, 1600);
        var ruleIds = CreateIds(recordCount, 1700);
        var orderIds = CreateIds(recordCount, 1800);
        var orderItemIds = CreateIds(recordCount, 1900);
        var paymentSnapshotIds = CreateIds(recordCount, 2000);
        var shipmentSnapshotIds = CreateIds(recordCount, 2100);
        var transactionIds = CreateIds(recordCount, 2200);
        var refundIds = CreateIds(recordCount, 2300);
        var shipmentIds = CreateIds(recordCount, 2400);
        var reservationIds = CreateIds(recordCount, 2500);
        var carrierMethodIds = CreateIds(recordCount, 2600);

        var brands = Enumerable.Range(1, recordCount)
            .Select(i => new Brand
            {
                Id = brandIds[i - 1],
                Name = $"Brand {i:00}",
                Slug = $"brand-{i:00}",
                Description = $"Seeded brand {i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var categories = Enumerable.Range(1, recordCount)
            .Select(i => new Category
            {
                Id = categoryIds[i - 1],
                Name = $"Category {i:00}",
                Slug = $"category-{i:00}",
                ParentId = i > 10 ? categoryIds[(i - 1) % 10] : null,
                IsActive = true,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var products = Enumerable.Range(1, recordCount)
            .Select(i => new Product
            {
                Id = productIds[i - 1],
                Name = $"Product {i:00}",
                Slug = $"product-{i:00}",
                Description = $"Seeded product {i:00} description",
                BrandId = brandIds[i - 1],
                CategoryId = categoryIds[i - 1],
                IsActive = true,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-(i - 1))
            })
            .ToList();

        var variants = Enumerable.Range(1, recordCount)
            .Select(i => new Variant
            {
                Id = variantIds[i - 1],
                ProductId = productIds[i - 1],
                SKU = $"SKU-{i:0000}",
                Price = 20 + (i * 5),
                CompareAtPrice = 25 + (i * 5),
                IsActive = true,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-(i - 1))
            })
            .ToList();

        var attributes = Enumerable.Range(1, recordCount)
            .Select(i => new ProductAttribute
            {
                Id = attributeIds[i - 1],
                Name = $"Attribute {i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var attributeValues = Enumerable.Range(1, recordCount)
            .Select(i => new AttributeValue
            {
                Id = attributeValueIds[i - 1],
                AttributeId = attributeIds[i - 1],
                VariantId = variantIds[i - 1],
                Value = $"Value {i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var media = Enumerable.Range(1, recordCount)
            .Select(i => new Media
            {
                Id = mediaIds[i - 1],
                ProductId = productIds[i - 1],
                Url = $"https://cdn.example.com/products/{i:00}.jpg",
                Type = "image",
                SortOrder = 1,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var users = Enumerable.Range(1, recordCount)
            .Select(i => new User
            {
                Id = userIds[i - 1],
                FirstName = $"First{i:00}",
                LastName = $"Last{i:00}",
                Email = $"user{i:00}@example.com",
                Password = $"hashed_password_{i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var customers = Enumerable.Range(1, recordCount)
            .Select(i => new Customer
            {
                Id = customerIds[i - 1],
                UserId = userIds[i - 1],
                Phone = $"+1000000{i:000}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-(i - 1))
            })
            .ToList();

        var addresses = Enumerable.Range(1, recordCount)
            .Select(i => new Address
            {
                Id = addressIds[i - 1],
                CustomerId = customerIds[i - 1],
                Country = "USA",
                City = $"City {i:00}",
                Street = $"{i:00} Market Street",
                PostalCode = $"100{i:00}",
                IsDefault = true,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var preferences = Enumerable.Range(1, recordCount)
            .Select(i => new Preferences
            {
                Id = preferenceIds[i - 1],
                CustomerId = customerIds[i - 1],
                Language = i % 2 == 0 ? "en" : "es",
                Currency = "USD",
                ReceiveEmails = i % 3 != 0,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var carts = Enumerable.Range(1, recordCount)
            .Select(i => new Cart
            {
                Id = cartIds[i - 1],
                CustomerId = customerIds[i - 1],
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-(i - 1))
            })
            .ToList();

        var cartItems = Enumerable.Range(1, recordCount)
            .Select(i => new CartItem
            {
                Id = cartItemIds[i - 1],
                CartId = cartIds[i - 1],
                VariantId = variantIds[i - 1],
                Quantity = (i % 4) + 1,
                UnitPrice = 20 + (i * 5),
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var warehouses = Enumerable.Range(1, recordCount)
            .Select(i => new Warehouse
            {
                Id = warehouseIds[i - 1],
                Name = $"Warehouse {i:00}",
                Location = $"Region {i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var stocks = Enumerable.Range(1, recordCount)
            .Select(i => new Stock
            {
                Id = stockIds[i - 1],
                VariantId = variantIds[i - 1],
                WarehouseId = warehouseIds[i - 1],
                Quantity = 100 + i,
                ReservedQuantity = i % 5,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var coupons = Enumerable.Range(1, recordCount)
            .Select(i => new Coupon
            {
                Id = couponIds[i - 1],
                Code = $"COUPON{i:00}",
                DiscountValue = i % 2 == 0 ? 5 + i : 10 + i,
                DiscountType = i % 2 == 0 ? "Fixed" : "Percent",
                IsActive = i % 5 != 0,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var discounts = Enumerable.Range(1, recordCount)
            .Select(i => new Discount
            {
                Id = discountIds[i - 1],
                Value = i % 2 == 0 ? 5 + i : 10 + i,
                Type = i % 2 == 0 ? "Fixed" : "Percent",
                CouponId = couponIds[i - 1],
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var rules = Enumerable.Range(1, recordCount)
            .Select(i => new Rule
            {
                Id = ruleIds[i - 1],
                DiscountId = discountIds[i - 1],
                Condition = $"cart.total >= {50 + (i * 5)}",
                Action = $"apply discount {i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var orders = Enumerable.Range(1, recordCount)
            .Select(i => new Order
            {
                Id = orderIds[i - 1],
                OrderNumber = $"ORD-{20260000 + i}",
                CustomerId = customerIds[i - 1],
                TotalAmount = (20 + (i * 5)) * ((i % 4) + 1),
                Currency = "USD",
                Status = i % 3 == 0 ? "Processing" : "Completed",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-(i - 1))
            })
            .ToList();

        var orderItems = Enumerable.Range(1, recordCount)
            .Select(i => new OrderItem
            {
                Id = orderItemIds[i - 1],
                OrderId = orderIds[i - 1],
                VariantId = variantIds[i - 1],
                ProductName = $"Product {i:00}",
                UnitPrice = 20 + (i * 5),
                Quantity = (i % 4) + 1,
                TotalPrice = (20 + (i * 5)) * ((i % 4) + 1),
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var paymentSnapshots = Enumerable.Range(1, recordCount)
            .Select(i => new PaymentSnapshot
            {
                Id = paymentSnapshotIds[i - 1],
                OrderId = orderIds[i - 1],
                Method = i % 2 == 0 ? "Card" : "PayPal",
                Amount = (20 + (i * 5)) * ((i % 4) + 1),
                Status = i % 3 == 0 ? "Pending" : "Captured",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var shipmentSnapshots = Enumerable.Range(1, recordCount)
            .Select(i => new ShipmentSnapshot
            {
                Id = shipmentSnapshotIds[i - 1],
                OrderId = orderIds[i - 1],
                Address = $"{i:00} Market Street, City {i:00}, USA",
                Carrier = $"Carrier {(i % 5) + 1}",
                TrackingNumber = $"SNAP-{i:0000}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var transactions = Enumerable.Range(1, recordCount)
            .Select(i => new Transaction
            {
                Id = transactionIds[i - 1],
                OrderId = orderIds[i - 1],
                Amount = (20 + (i * 5)) * ((i % 4) + 1),
                Currency = "USD",
                Status = i % 3 == 0 ? "Authorized" : "Settled",
                Provider = i % 2 == 0 ? "Stripe" : "PayPal",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var refunds = Enumerable.Range(1, recordCount)
            .Select(i => new Refund
            {
                Id = refundIds[i - 1],
                TransactionId = transactionIds[i - 1],
                Amount = Math.Round(((20 + (i * 5)) * ((i % 4) + 1)) * 0.1m, 2),
                Reason = $"Partial refund {i:00}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var shipments = Enumerable.Range(1, recordCount)
            .Select(i => new Shipment
            {
                Id = shipmentIds[i - 1],
                OrderId = orderIds[i - 1],
                Status = i % 3 == 0 ? "Packed" : "Delivered",
                TrackingNumber = $"SHIP-{i:0000}",
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var reservations = Enumerable.Range(1, recordCount)
            .Select(i => new Reservation
            {
                Id = reservationIds[i - 1],
                VariantId = variantIds[i - 1],
                Quantity = (i % 3) + 1,
                ExpiresAt = now.AddDays(7 + i),
                CartId = i % 2 == 0 ? cartIds[i - 1] : null,
                OrderId = i % 2 != 0 ? orderIds[i - 1] : null,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        var carrierMethods = Enumerable.Range(1, recordCount)
            .Select(i => new CarrierMethod
            {
                Id = carrierMethodIds[i - 1],
                Name = $"Carrier Method {i:00}",
                Price = 4 + i,
                EstimatedDays = (i % 7) + 1,
                CreatedAt = now.AddDays(-i),
                UpdatedAt = now.AddDays(-i)
            })
            .ToList();

        await context.Brands.AddRangeAsync(brands, cancellationToken);
        await context.Categories.AddRangeAsync(categories, cancellationToken);
        await context.Attributes.AddRangeAsync(attributes, cancellationToken);
        await context.Users.AddRangeAsync(users, cancellationToken);
        await context.Customers.AddRangeAsync(customers, cancellationToken);
        await context.Warehouses.AddRangeAsync(warehouses, cancellationToken);
        await context.Coupons.AddRangeAsync(coupons, cancellationToken);
        await context.CarrierMethods.AddRangeAsync(carrierMethods, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        await context.Products.AddRangeAsync(products, cancellationToken);
        await context.Discounts.AddRangeAsync(discounts, cancellationToken);
        await context.Addresses.AddRangeAsync(addresses, cancellationToken);
        await context.Preferences.AddRangeAsync(preferences, cancellationToken);
        await context.Carts.AddRangeAsync(carts, cancellationToken);
        await context.Orders.AddRangeAsync(orders, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        await context.Variants.AddRangeAsync(variants, cancellationToken);
        await context.Rules.AddRangeAsync(rules, cancellationToken);
        await context.PaymentSnapshots.AddRangeAsync(paymentSnapshots, cancellationToken);
        await context.ShipmentSnapshots.AddRangeAsync(shipmentSnapshots, cancellationToken);
        await context.Transactions.AddRangeAsync(transactions, cancellationToken);
        await context.Shipments.AddRangeAsync(shipments, cancellationToken);
        await context.Medias.AddRangeAsync(media, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        await context.AttributeValues.AddRangeAsync(attributeValues, cancellationToken);
        await context.CartItems.AddRangeAsync(cartItems, cancellationToken);
        await context.OrderItems.AddRangeAsync(orderItems, cancellationToken);
        await context.Reservations.AddRangeAsync(reservations, cancellationToken);
        await context.Stocks.AddRangeAsync(stocks, cancellationToken);
        await context.Refunds.AddRangeAsync(refunds, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static List<Guid> CreateIds(int count, int offset) =>
        Enumerable.Range(1, count)
            .Select(index => Guid.Parse($"00000000-0000-0000-0000-{offset + index:000000000000}"))
            .ToList();
}
