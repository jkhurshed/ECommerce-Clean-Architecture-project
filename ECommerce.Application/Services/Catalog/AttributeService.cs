using ECommerce.Application.Common;
using ECommerce.Application.Common.Interfaces.Persistence;
using ECommerce.Application.Common.Interfaces.Services;
using DomainAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.Application.Services.Catalog;

public class AttributeService(IRepository<DomainAttribute> repository, IUnitOfWork unitOfWork): IAttributeService
{
    public async Task<DomainAttribute?> GetAttributeByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }
    
    public async Task AddAsync(DomainAttribute attribute)
    {
        await repository.AddAsync(attribute);
        await unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
        await unitOfWork.SaveChangesAsync();
    }
}