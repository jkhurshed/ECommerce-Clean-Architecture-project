using ECommerce.Application.Common.Interfaces.Authentication;
using ECommerce.Application.Common.Interfaces.Persistence;
using ECommerce.Application.Common.Interfaces.Services;
using ECommerce.Application.Services.Authentication;
using ECommerce.Infrastructure.Authentication;
using ECommerce.Infrastructure.Persistence;
using ECommerce.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
        
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}