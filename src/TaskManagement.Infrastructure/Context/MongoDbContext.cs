using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Domain.Entities.External;
using TaskManagement.Domain.Entities.Internal;

namespace TaskManagement.Infrastructure.MongoDB.Context;

[ExcludeFromCodeCoverage]
public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoCollection<Project> Projects => _database.GetCollection<Project>("Users");

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    public IMongoCollection<Domain.Entities.Internal.Task> Tasks => _database.GetCollection<Domain.Entities.Internal.Task>("Tasks");
}
