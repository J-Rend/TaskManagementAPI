using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Infrastructure.Repositories.MongoDB;

namespace TaskManagement.CrossCutting.Resolvers;

public static class InfrastructureResolver
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
