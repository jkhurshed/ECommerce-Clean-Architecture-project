using ECommerce.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence;

public class EfRepository<TEntity>(AppDbContext context): IRepository<TEntity> where TEntity : class
{
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null) context.Set<TEntity>().Remove(entity);
    }
}
