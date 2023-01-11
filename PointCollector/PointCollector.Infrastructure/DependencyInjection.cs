using Microsoft.Extensions.Configuration;
using PointCollector.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using PointCollector.Infrastructure.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence.Customers;
using PointCollector.Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using PointCollector.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PointCollector.Domain.Entities.Customers.Rules;
using PointCollector.Application.Customers;
using PointCollector.Application.Common.Interfaces.Persistence.Workspaces;
using PointCollector.Domain.Entities.Workspaces.Rules;
using PointCollector.Application.Workspaces;
using PointCollector.Application.Account;
using PointCollector.Domain.Entities.Account.Rules;
using PointCollector.Application.Common.Interfaces.Persistence.Account;

namespace PointCollector.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICustomerUniquenessChecker, CustomerUniquenessChecker>();
        services.AddScoped<IWorkspaceUniquenessChecker, WorkspaceUniquenessChecker>();
        services.AddScoped<IAccountExistForCustomerChecker, AccountExistForCustomerChecker>();
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
            options.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}
