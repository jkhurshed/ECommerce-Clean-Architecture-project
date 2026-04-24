using ECommerce.Domain.Entities.Identity;

namespace ECommerce.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    public Task<User?> GetUserByEmailAsync(string email);
    public Task AddAsync(User user);
}