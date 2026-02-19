using Microsoft.Extensions.DependencyInjection;
using LogThemALL.Services;

namespace LogThemALL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAdvancedLogging(this IServiceCollection services, string connectionString, string serviceName)
    {
        services.AddSingleton<IAuditService>(sp => new AuditService(connectionString, serviceName));
        return services;
    }
}
