using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Application.UseCases.Project.GetUserProjects;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
[Produces("application/json")]
[Tags("Users")]
public class UsersController : TaskManagementControllerBase
{
    /// <summary>
    /// Retorna todos os projetos acessíveis por um usuário.
    /// </summary>
    /// <param name="useCaseHandler">Handler responsável pela consulta.</param>
    /// <param name="userId">ID do usuário.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição.</param>
    /// <returns>Lista de projetos associados ao usuário.</returns>
    [HttpGet("{userId}/projects")]
    [ProducesResponseType(typeof(IEnumerable<GetUserProjectsOutput>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserProjects(
        [FromServices] IGetUserProjectsHandler useCaseHandler,
        [FromRoute] string userId,
        CancellationToken cancellationToken)
    {
        var input = new GetUserProjectsInput(userId);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }
}
