namespace ECommerce.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task DeleteAsync(Guid id);
}
