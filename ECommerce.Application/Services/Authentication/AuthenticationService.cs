using ECommerce.Application.Common.Interfaces.Authentication;

namespace ECommerce.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        
        // Create jwt token
        Guid userId = Guid.NewGuid();
        
        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(
            userId, 
            firstName, 
            lastName, 
            email, 
            token
            );
    }
    
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }
}