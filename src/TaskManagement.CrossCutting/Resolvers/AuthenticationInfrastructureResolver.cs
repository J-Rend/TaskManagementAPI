using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Infrastructure.Permissioning.Services;

namespace TaskManagement.CrossCutting.Resolvers;

public static class AuthenticationInfrastructureResolver
{
    public static IServiceCollection ConfigureAuthenticationInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
