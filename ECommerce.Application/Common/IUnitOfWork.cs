namespace ECommerce.Application.Common;

public interface IUnitOfWork
{
    Task<Guid> SaveChangesAsync();
}