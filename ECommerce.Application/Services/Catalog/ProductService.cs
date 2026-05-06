using ECommerce.Application.Common;
using ECommerce.Application.Common.Interfaces.Persistence;
using ECommerce.Application.Services.Catalog.Services;
using ECommerce.Domain.Entities.Catalog;

namespace ECommerce.Application.Services.Catalog;

public class ProductService(IUnitOfWork unitOfWork, IProductRepository repository): IProductService
{
    public async Task AddAsync(Product product)
    {
        await repository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
        await unitOfWork.SaveChangesAsync();
    }
    
    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }
}