using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Infrastructure.MongoDB.Context;

namespace TaskManagement.Infrastructure.Repositories.MongoDB;

[ExcludeFromCodeCoverage]
public class TaskRepository : ITaskRepository
{
    private readonly IMongoDbContext _mongoDbContext;

    public TaskRepository(IMongoDbContext mongoDbContext)
    {
        ArgumentNullException.ThrowIfNull(mongoDbContext);

        _mongoDbContext = mongoDbContext;
    }

    public async Task<IEnumerable<Domain.Entities.Internal.Task>> GetTasksByProject(string projectId, CancellationToken cancellationToken)
    {
        return await _mongoDbContext.Tasks
                    .Find(task => task.ProjectId == projectId)
                    .ToListAsync(cancellationToken);
    }

    public async Task<Domain.Entities.Internal.Task> CreateAsync(Domain.Entities.Internal.Task task, CancellationToken cancellationToken)
    {
        await _mongoDbContext
                        .Tasks
                        .InsertOneAsync(task, cancellationToken: cancellationToken);

        return task;
    }

    public async Task<Domain.Entities.Internal.Task?> GetTaskByIdAsync(string taskId, CancellationToken cancellationToken)
    {
        return await _mongoDbContext
                    .Tasks
                    .Find(task => task.Id == taskId)
                    .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(Domain.Entities.Internal.Task task, CancellationToken cancellationToken)
    {
        await _mongoDbContext
                .Tasks
                .ReplaceOneAsync(t => t.Id == task.Id, task, cancellationToken: cancellationToken);
    }
}
