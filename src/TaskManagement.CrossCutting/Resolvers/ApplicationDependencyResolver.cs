using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.UseCases;
using TaskManagement.Application.UseCases.CreateUser;

namespace TaskManagement.IoC.Injection;

public static class ApplicationDependencyResolver
{
    public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUseCaseHandler<CreateUserInput, CreateUserOutput>, CreateUserHandler>();

        return services;
    }
}
