using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Infrastructure.MongoDB;
using TaskManagement.Infrastructure.MongoDB.Context;
using TaskManagement.Infrastructure.Repositories.MongoDB;

namespace TaskManagement.CrossCutting.Resolvers;

[ExcludeFromCodeCoverage]
public static class MongoDbInfrastructureResolver
{
    public static IServiceCollection ConfigureMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<IMongoDbContext, MongoDbContext>();

        services.ConfigureRepositories();

        return services;
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}
