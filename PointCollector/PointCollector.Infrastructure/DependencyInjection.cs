using Microsoft.Extensions.Configuration;
using PointCollector.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using PointCollector.Infrastructure.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using PointCollector.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PointCollector.Domain.Entities.Customers.Rules;
using PointCollector.Application.Customers;

namespace PointCollector.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICustomerUniquenessChecker, CustomerUniquenessChecker>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind("JwtSettings", jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });


        services.AddDbContext<PointCollectorContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}
