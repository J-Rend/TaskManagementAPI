using System.Diagnostics.CodeAnalysis;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;

namespace TaskManagement.Infrastructure.Permissioning.Services;

[ExcludeFromCodeCoverage]
public class InMemoryPermissionService : IPermissionService
{
    private readonly Dictionary<string, List<string>> _permissionsByRole = new()
    {
        ["Admin"] = new List<string> { "CreateTask", "DeleteTask", "FinishProject", "AssignTask" },
        ["Manager"] = new List<string> { "CreateTask", "AssignTask", "FinishProject" },
        ["User"] = new List<string> { "CreateTask" }
    };

    public bool HasPermission(string role, string permission)
    {
        if (string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(permission))
            return false;

        return _permissionsByRole.TryGetValue(role, out var permissions)
               && permissions.Contains(permission);
    }
}
