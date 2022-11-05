using Microsoft.Extensions.DependencyInjection;
using PointCollector.Application.Services.Authentication;

namespace PointCollector.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
