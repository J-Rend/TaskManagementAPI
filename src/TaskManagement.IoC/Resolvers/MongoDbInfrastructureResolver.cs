using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Infrastructure.MongoDB;
using TaskManagement.Infrastructure.MongoDB.Context;

namespace TaskManagement.CrossCutting.Resolvers;

public static class MongoDbInfrastructureResolver
{
    public static IServiceCollection ConfigureMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<IMongoDbContext, MongoDbContext>();

        return services;
    }

}
