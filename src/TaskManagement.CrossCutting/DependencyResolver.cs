using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.CrossCutting.Resolvers;
using TaskManagement.IoC.Injection;

namespace TaskManagement.CrossCutting;

[ExcludeFromCodeCoverage]
public static class DependencyResolver
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMongoDb(configuration);

        services.ConfigureApplicationDependencies();

        return services;
    }
}
