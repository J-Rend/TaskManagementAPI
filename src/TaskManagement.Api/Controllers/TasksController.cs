using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.Task;
using TaskManagement.Application.UseCases.Task.CreateTask;
using TaskManagement.Application.UseCases.Task.UpdateTaskComments;
using TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
public class TasksController : TaskManagementControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTask(
        [FromServices] ICreateTaskHandler useCaseHandler,
        [FromBody] CreateTaskRequest request,
        CancellationToken cancellationToken
        )
    {
        var input = new CreateTaskInput(request.Title,request.Description,request.DueDate,request.Status,request.Priority,request.ProjectId);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    [HttpPatch("{taskId}/status")]
    public async Task<IActionResult> UpdateTaskStatus(
        [FromServices] IUpdateTaskStatusHandler useCaseHandler,
        [FromRoute] string taskId,
        [FromBody] UpdateTaskStatusRequest request,
        CancellationToken cancellationToken
        )
    {
        var input = new UpdateTaskStatusInput(taskId, request.Status);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    [HttpPost("{taskId}/comments")]
    public async Task<IActionResult> AddCommentToTask(
        [FromServices] IUpdateTaskCommentsHandler useCaseHandler,
        [FromRoute] string taskId,
        [FromBody] UpdateTaskCommentsRequest request,
        CancellationToken cancellationToken
        )
    {
        var input = new UpdateTaskCommentsInput(taskId, request.Comment);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }
}
