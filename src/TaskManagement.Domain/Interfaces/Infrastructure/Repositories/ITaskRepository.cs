namespace TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Entities.Internal.Task>> GetTasksByProjectAsync(string projectId, CancellationToken cancellationToken);

    Task<Entities.Internal.Task> CreateAsync(Entities.Internal.Task task, CancellationToken cancellationToken);

    Task<Domain.Entities.Internal.Task?> GetTaskByIdAsync(string taskId, CancellationToken cancellationToken);

    Task UpdateAsync(Domain.Entities.Internal.Task task, CancellationToken cancellationToken);

    Task<long> CountTasksByProjectAsync(string projectId, CancellationToken cancellationToken);

    Task<IEnumerable<Domain.Entities.Internal.Task>> GetTasksByProjectListAsync(IEnumerable<string> projectIds, CancellationToken cancellationToken);
}
