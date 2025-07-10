using TaskManagement.Infrastructure.MongoDB;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

public class ProjectRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public ProjectRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }
}
