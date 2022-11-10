using PointCollector.API.Common.Mapping;

namespace PointCollector.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            return services;
        }
    }
}