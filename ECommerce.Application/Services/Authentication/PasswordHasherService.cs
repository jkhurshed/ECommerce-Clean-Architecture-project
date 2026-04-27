using ECommerce.Application.Common.Interfaces.Authentication;

namespace ECommerce.Application.Services.Authentication;

public class PasswordHasherService : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyHashedPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}