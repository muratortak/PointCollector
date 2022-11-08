using Microsoft.Extensions.Configuration;
using PointCollector.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using PointCollector.Infrastructure.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Application.Common.Interfaces.Authentication;

namespace PointCollector.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
