using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.User;
using TaskManagement.Application.UseCases.CreateUser;
using TaskManagement.Application.UseCases.GetUserProjects;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : TaskManagementControllerBase
{
    /// <summary>
    /// Creates a new user.
    /// Available roles: Default, Manager
    /// </summary>
    /// <param name="request">The request containing user details.</param>
    /// <returns>A result indicating success or failure.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromServices] ICreateUserHandler useCaseHandler,
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken
        )
    {
        var input = new CreateUserInput(request.Name, request.Role);

        var result = await useCaseHandler.ExecuteAsync(input,cancellationToken);

        return SendResponse(result);
    }

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
