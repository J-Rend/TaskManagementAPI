using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
}
