namespace TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;

public interface IPermissionService
{
    bool HasPermission(string role, string permission);
}
