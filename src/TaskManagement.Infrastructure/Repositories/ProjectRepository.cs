using MongoDB.Driver;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces.Repositories;
using TaskManagement.Infrastructure.MongoDB.Context;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

public class ProjectRepository : IProjectRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public ProjectRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }

    public async Task<IEnumerable<Project>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _mongoDbContext
                    .Projects
                    .Find(project => project.ResponsibleUserId.Equals(userId))
                    .ToListAsync(cancellationToken);

    }
}
