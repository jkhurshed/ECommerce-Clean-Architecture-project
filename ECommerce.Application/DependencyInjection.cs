using ECommerce.Application.Common.Interfaces.Authentication;
using ECommerce.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
namespace ECommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
        
        return services;
    }
}