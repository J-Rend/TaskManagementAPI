using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.Project;
using TaskManagement.Application.UseCases.Project.CreateProject;
using TaskManagement.Application.UseCases.Task.GetProjectTasks;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
public class ProjectsController : TaskManagementControllerBase
{
    [HttpGet("{projectId}/tasks")]
    public async Task<IActionResult> GetProjectTasks(
        [FromServices] IGetProjectTasksHandler useCaseHandler,
        [FromRoute] string projectId,
        CancellationToken cancellationToken
        )
    {
        var input = new GetProjectTasksInput(projectId);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(
        [FromServices] ICreateProjectHandler useCaseHandler,
        [FromBody] CreateProjectRequest request,
        CancellationToken cancellationToken
        )
    {
        var input = new CreateProjectInput(
            request.Title,
            request.Description
        );

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }
}
