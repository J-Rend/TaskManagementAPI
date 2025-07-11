using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Application.UseCases.Project.GetUserProjects;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
public class UsersController : TaskManagementControllerBase
{
    [HttpGet("{userId}/projects")]
    public async Task<IActionResult> GetUserProjects(
        [FromServices] IGetUserProjectsHandler useCaseHandler,
        [FromRoute] string userId,
        CancellationToken cancellationToken
        )
    {
        var input = new GetUserProjectsInput(userId);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }
}
