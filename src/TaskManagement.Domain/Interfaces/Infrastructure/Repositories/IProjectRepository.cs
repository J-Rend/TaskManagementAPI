using TaskManagement.Domain.Entities.Internal;

namespace TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);

    Task<Project> CreateProjectAsync(Project project, CancellationToken cancellationToken);

    Task<Project?> GetByIdAsync(string projectId, CancellationToken cancellationToken);

    System.Threading.Tasks.Task UpdateAsync(Project project, CancellationToken cancellationToken);
}
