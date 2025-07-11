using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.UseCases.CreateUser;
using TaskManagement.Application.UseCases.GetUserProjects;

namespace TaskManagement.IoC.Injection;

public static class ApplicationDependencyResolver
{
    public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserHandler, CreateUserHandler>();
        services.AddScoped<IGetUserProjectsHandler, GetUserProjectsHandler>();


        return services;
    }
}
