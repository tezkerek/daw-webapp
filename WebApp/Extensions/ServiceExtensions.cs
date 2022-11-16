using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
            options =>
            {
                var jwtBytes = System.Text.Encoding.ASCII.GetBytes(appSettings.JwtSecret);
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(jwtBytes);
            });

        return services;
    }
}