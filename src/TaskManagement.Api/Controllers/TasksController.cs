using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.Task;
using TaskManagement.Application.UseCases.Task.CreateTask;
using TaskManagement.Application.UseCases.Task.RemoveTask;
using TaskManagement.Application.UseCases.Task.UpdateTaskComments;
using TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
[Produces("application/json")]
[Tags("Tasks")]
public class TasksController : TaskManagementControllerBase
{
    /// <summary>
    /// Cria uma nova tarefa.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de criação.</param>
    /// <param name="request">Dados para criação da tarefa.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Detalhes da tarefa criada.</returns>
    [Authorize]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CreateTaskOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTask(
        [FromServices] ICreateTaskHandler useCaseHandler,
        [FromBody] CreateTaskRequest request,
        CancellationToken cancellationToken)
    {
        var input = new CreateTaskInput(
            request.Title,
            request.Description,
            request.DueDate,
            request.Status,
            request.Priority,
            request.ProjectId
        );

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    /// <summary>
    /// Atualiza o status de uma tarefa.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de atualização de status.</param>
    /// <param name="taskId">ID da tarefa a ser atualizada.</param>
    /// <param name="request">Novo status da tarefa.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Status da operação.</returns>
    [Authorize]
    [HttpPatch("{taskId}/status")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTaskStatus(
        [FromServices] IUpdateTaskStatusHandler useCaseHandler,
        [FromRoute] string taskId,
        [FromBody] UpdateTaskStatusRequest request,
        CancellationToken cancellationToken)
    {
        var input = new UpdateTaskStatusInput(taskId, request.Status);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    /// <summary>
    /// Adiciona um comentário a uma tarefa.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de comentários.</param>
    /// <param name="taskId">ID da tarefa.</param>
    /// <param name="request">Comentário a ser adicionado.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Status da operação.</returns>
    [Authorize]
    [HttpPost("{taskId}/comments")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddCommentToTask(
        [FromServices] IUpdateTaskCommentsHandler useCaseHandler,
        [FromRoute] string taskId,
        [FromBody] UpdateTaskCommentsRequest request,
        CancellationToken cancellationToken)
    {
        var input = new UpdateTaskCommentsInput(taskId, request.Comment);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }

    /// <summary>
    /// Remove uma tarefa existente.
    /// </summary>
    /// <param name="useCaseHandler">Handler do use case de remoção.</param>
    /// <param name="taskId">ID da tarefa a ser removida.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Status da operação.</returns>
    [Authorize]
    [HttpDelete("{taskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveTask(
        [FromServices] IRemoveTaskHandler useCaseHandler,
        [FromRoute] string taskId,
        CancellationToken cancellationToken)
    {
        var input = new RemoveTaskInput(taskId);

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }
}
