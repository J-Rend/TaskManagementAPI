using TaskManagement.Infrastructure.MongoDB;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

public class TaskRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public TaskRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }
}
