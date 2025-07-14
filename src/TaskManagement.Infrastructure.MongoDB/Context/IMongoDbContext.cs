using MongoDB.Driver;
using TaskManagement.Domain.Entities.External;
using TaskManagement.Domain.Entities.Internal;

namespace TaskManagement.Infrastructure.MongoDB.Context;

public interface IMongoDbContext
{
    IMongoCollection<Domain.Entities.Internal.Task> Tasks { get; }
    IMongoCollection<Project> Projects { get; }
    IMongoCollection<User> Users { get; }
}
