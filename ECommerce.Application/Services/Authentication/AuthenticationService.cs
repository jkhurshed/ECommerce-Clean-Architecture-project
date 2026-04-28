using ECommerce.Application.Common.Interfaces.Authentication;
using ECommerce.Application.Common.Interfaces.Persistence;
using ECommerce.Application.Services.Authentication.Interfaces;
using ECommerce.Domain.Entities.Identity;

namespace ECommerce.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator jwtTokenGenerator, 
    IUserRepository userRepository,
    IPasswordHasher passwordHasher
    ) : IAuthenticationService
{
    public async Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        // If the user already exists, throw an exception
        var checkUser = await userRepository.GetUserByEmailAsync(email);
        if (checkUser is not null)
        {
            throw new InvalidOperationException("User already exists");
        }
        
        // Hash password
        var hashedPassword = passwordHasher.HashPassword(password);
        
        // Create user
        var user = new User{
            FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = hashedPassword
        };
        
        // add and save user to database
        await userRepository.AddAsync(user);
        
        // Create jwt token
        var token = jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

        return new AuthenticationResult(
            user.Id,
            firstName,
            lastName,
            email,
            token
        );
    }
    
    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var user = await userRepository.GetUserByEmailAsync(email);
        
        if (user is null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var isPasswordValid = passwordHasher.VerifyHashedPassword(password, user.Password);
        if (!isPasswordValid)
            throw new UnauthorizedAccessException("Invalid email or password.");
        
        var token = jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(
            user.Id, 
            user.FirstName,  
            user.LastName, 
            email,
            token
        );
    }
}