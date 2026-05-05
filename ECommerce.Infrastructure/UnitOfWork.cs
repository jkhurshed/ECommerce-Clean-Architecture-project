using ECommerce.Application.Common;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    public async Task<Guid> SaveChangesAsync()
    {
        await context.SaveChangesAsync();
        return Guid.NewGuid();
    }
}