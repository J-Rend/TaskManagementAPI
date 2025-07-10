using MongoDB.Driver;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.MongoDB.Context;

public interface IMongoDbContext
{
    IMongoCollection<Domain.Entities.Task> Tasks { get; }
    IMongoCollection<Project> Projects { get; }
    IMongoCollection<User> Users { get; }
}
