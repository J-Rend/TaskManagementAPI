using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Infrastructure.MongoDB.Context;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

public class UserRepository : IUserRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public UserRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(user);

        await _mongoDbContext.Users.InsertOneAsync(user,null,cancellationToken);

        return user;
    }
}
