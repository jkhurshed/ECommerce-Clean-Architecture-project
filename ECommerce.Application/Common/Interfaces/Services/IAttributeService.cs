using DomainAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.Application.Common.Interfaces.Services;

public interface IAttributeService
{
    Task<DomainAttribute?> GetAttributeByIdAsync(Guid id);
    Task AddAsync(DomainAttribute attribute);
    Task DeleteAsync(Guid id);
}