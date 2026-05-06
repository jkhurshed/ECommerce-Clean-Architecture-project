using ECommerce.Domain.Entities.Catalog;

namespace ECommerce.Application.Services.Catalog.Services;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task DeleteAsync(Guid id);
}