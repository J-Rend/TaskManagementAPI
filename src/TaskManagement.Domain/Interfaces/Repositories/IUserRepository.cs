using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken);
}
