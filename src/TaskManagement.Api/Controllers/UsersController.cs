using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.User;
using TaskManagement.Application.UseCases;
using TaskManagement.Application.UseCases.CreateUser;

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
        [FromServices] IUseCaseHandler<CreateUserInput, CreateUserOutput> useCaseHandler,
        [FromBody] CreateUserRequest request
        )
    {
        var input = new CreateUserInput
        {
            Name = request.Name,
            Role = request.Role
        };

        var result = await useCaseHandler.ExecuteAsync(input);

        return SendResponse(result);
    }
}
