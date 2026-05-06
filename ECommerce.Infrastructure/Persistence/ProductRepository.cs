using ECommerce.Application.Common.Interfaces.Persistence;
using ECommerce.Domain.Entities.Catalog;

namespace ECommerce.Infrastructure.Persistence;

public class ProductRepository(AppDbContext context): IProductRepository
{
    public async Task<Product> AddAsync(Product product)
    {
        await context.Set<Product>().AddAsync(product);
        return product;
    }
    
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await context.Set<Product>().FindAsync(id);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product != null) context.Set<Product>().Remove(product);
    }
}