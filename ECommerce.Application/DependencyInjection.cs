using ECommerce.Application.Common.Interfaces.Authentication;
using ECommerce.Application.Common.Interfaces.Services;
using ECommerce.Application.Services.Catalog;
using ECommerce.Application.Services.Authentication;
using ECommerce.Application.Services.Authentication.Interfaces;
using ECommerce.Application.Services.Catalog.Services;
using Microsoft.Extensions.DependencyInjection;
namespace ECommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
        services.AddScoped<IAttributeService, AttributeService>();
        services.AddScoped<IProductService, ProductService>();
        
        return services;
    }
}