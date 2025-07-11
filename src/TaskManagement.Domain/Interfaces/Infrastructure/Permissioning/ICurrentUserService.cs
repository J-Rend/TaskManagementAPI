using TaskManagement.Domain.Entities.External;

namespace TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;

public interface ICurrentUserService
{
    User GetCurrentUser();
}
