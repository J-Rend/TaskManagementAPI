using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.CrossCutting.Resolvers;
using TaskManagement.IoC.Injection;

namespace TaskManagement.CrossCutting;

public static class DependencyResolver
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMongoDb(configuration);

        services.ConfigureRepositories();
        services.ConfigureApplicationDependencies();

        return services;
    }
}
