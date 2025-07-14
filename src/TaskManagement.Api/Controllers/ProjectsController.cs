using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.Project;
using TaskManagement.Application.UseCases.Project.CreateProject;
using TaskManagement.Application.UseCases.Project.RemoveProject;
using TaskManagement.Application.UseCases.Task.GetProjectTasks;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
[Produces("application/json")]
[Tags("Projects")]
public class ProjectsController : TaskManagementControllerBase
{
    /// <summary>
    /// Retorna todas as tarefas associadas a um projeto.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de listagem de tarefas.</param>
    /// <param name="projectId">ID do projeto.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição.</param>
    /// <returns>Lista de tarefas do projeto.</returns>
    [HttpGet("{projectId}/tasks")]
    [ProducesResponseType(typeof(IEnumerable<GetProjectTasksOutput>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProjectTasks(
        [FromServices] IGetProjectTasksHandler useCaseHandler,
        [FromRoute] string projectId,
        CancellationToken cancellationToken)
    {
        var input = new GetProjectTasksInput(projectId);
        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);
        return SendResponse(result);
    }

    /// <summary>
    /// Cria um novo projeto.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de criação de projeto.</param>
    /// <param name="request">Dados para criação do projeto.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição.</param>
    /// <returns>Detalhes do projeto criado.</returns>
    [Authorize]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CreateProjectOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProject(
        [FromServices] ICreateProjectHandler useCaseHandler,
        [FromBody] CreateProjectRequest request,
        CancellationToken cancellationToken)
    {
        var input = new CreateProjectInput(
            request.Title,
            request.Description
        );

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    /// <summary>
    /// Remove um projeto existente.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de remoção.</param>
    /// <param name="projectId">ID do projeto a ser removido.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição.</param>
    /// <returns>Status da remoção.</returns>
    [Authorize]
    [HttpDelete("{projectId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveProject(
        [FromServices] IRemoveProjectHandler useCaseHandler,
        [FromRoute] string projectId,
        CancellationToken cancellationToken)
    {
        var input = new RemoveProjectInput(projectId);
        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);
        return SendResponse(result);
    }
}
