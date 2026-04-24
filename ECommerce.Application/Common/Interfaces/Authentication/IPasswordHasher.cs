namespace ECommerce.Application.Common.Interfaces.Authentication;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}