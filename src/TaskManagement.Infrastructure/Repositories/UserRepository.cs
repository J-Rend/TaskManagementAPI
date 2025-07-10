using TaskManagement.Infrastructure.MongoDB;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

public class UserRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public UserRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }
}
