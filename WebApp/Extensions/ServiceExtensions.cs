using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using WebApp.Jwt;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;

namespace WebApp.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection SetupScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtUtils, JwtUtils>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection SetupDatabase(
        this IServiceCollection services,
        AppSettings appSettings
    )
    {
        services.AddDbContext<AppDbContext>(
            options => { options.UseNpgsql(appSettings.DbConnectionString); }
        );

        return services;
    }

    public static IServiceCollection SetupIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, UserRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }

    public static IServiceCollection SetupJwtAuthentication(
        this IServiceCollection services,
        AppSettings appSettings
    )
    {
        services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(
            JwtBearerDefaults.AuthenticationScheme,
            options =>
            {
                options.SaveToken = true;
                
                var jwtBytes = System.Text.Encoding.UTF8.GetBytes(appSettings.JwtSecret);
                options.TokenValidationParameters.IssuerSigningKey =
                    new SymmetricSecurityKey(jwtBytes);

                options.TokenValidationParameters.ValidIssuer = appSettings.JwtIssuer;
                options.TokenValidationParameters.ValidAudience = appSettings.JwtAudience;
                options.TokenValidationParameters.ValidateIssuer = true;
                options.TokenValidationParameters.ValidateAudience = true;
                options.TokenValidationParameters.ValidateLifetime = false;
                options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                
            }
        );

        return services;
    }
}