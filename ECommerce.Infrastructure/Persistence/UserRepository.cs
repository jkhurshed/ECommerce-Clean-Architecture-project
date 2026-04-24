using ECommerce.Application.Common.Interfaces.Persistence;
using ECommerce.Domain.Entities.Identity;

namespace ECommerce.Infrastructure.Persistence;

public class UserRepository(AppDbContext context) : IUserRepository
{

    public async Task AddAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return context.Users.SingleOrDefault(x => x.Email == email)!;
    }
}