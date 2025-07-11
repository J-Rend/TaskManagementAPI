using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Domain.Entities.External;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;

namespace TaskManagement.Infrastructure.Permissioning.Services;

[ExcludeFromCodeCoverage]
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        ArgumentNullException.ThrowIfNull(httpContextAccessor);

        _httpContextAccessor = httpContextAccessor;
    }

    public User GetCurrentUser()
    {
        string? externalIdentifier = _httpContextAccessor
                                        .HttpContext?
                                        .Request
                                        .Headers["X-User-Id"]
                                        .FirstOrDefault() ??
                                        throw new UnauthorizedAccessException("User identifier is missing in the request headers.");

        string role = _httpContextAccessor
                        .HttpContext?
                        .Request
                        .Headers["X-User-Role"]
                        .FirstOrDefault() ?? 
                        "User";

        return new User(externalIdentifier, role);
    }
}
