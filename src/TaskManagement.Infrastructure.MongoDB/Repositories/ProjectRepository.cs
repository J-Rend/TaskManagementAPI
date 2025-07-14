using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Domain.Entities.Internal;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Infrastructure.MongoDB.Context;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

[ExcludeFromCodeCoverage]
public class ProjectRepository : IProjectRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public ProjectRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }

    public async Task<Project?> GetByIdAsync(string projectId, CancellationToken cancellationToken)
    {
        return await _mongoDbContext
                    .Projects
                    .Find(project => project.Id.Equals(projectId))
                    .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Project>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _mongoDbContext
                    .Projects
                    .Find(project => project.UserId.Equals(userId))
                    .ToListAsync(cancellationToken);

    }

    public async Task<Project> CreateProjectAsync(Project project, CancellationToken cancellationToken)
    {
        await _mongoDbContext
                    .Projects
                    .InsertOneAsync(project, cancellationToken: cancellationToken);

        return project;
    }

    public async System.Threading.Tasks.Task UpdateAsync(Project project, CancellationToken cancellationToken)
    {
        await _mongoDbContext
                .Projects
                .ReplaceOneAsync(p => p.Id == project.Id, project, cancellationToken: cancellationToken);
    }
}
