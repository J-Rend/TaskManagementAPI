using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TaskManagement.Infrastructure.MongoDB.Context;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoCollection<Domain.Entities.Project> Projects => _database.GetCollection<Domain.Entities.Project>("Users");

    public IMongoCollection<Domain.Entities.User> Users => _database.GetCollection<Domain.Entities.User>("Users");

    public IMongoCollection<Domain.Entities.Task> Tasks => _database.GetCollection<Domain.Entities.Task>("Tasks");
}
