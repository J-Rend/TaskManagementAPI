using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Domain.ValueObjects;

namespace TaskManagement.Application.UseCases.Task.UpdateTaskComments;

public class UpdateTaskCommentsHandler : IUpdateTaskCommentsHandler
{
    private readonly ITaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateTaskCommentsHandler(ITaskRepository taskRepository, ICurrentUserService currentUserService)
    {
        ArgumentNullException.ThrowIfNull(taskRepository);
        ArgumentNullException.ThrowIfNull(currentUserService);

        _currentUserService = currentUserService;
        _taskRepository = taskRepository;
    }

    public async Task<Result<UpdateTaskCommentsOutput>> ExecuteAsync(UpdateTaskCommentsInput input, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        var task = await _taskRepository.GetTaskByIdAsync(input.TaskId, cancellationToken);

        if (task is null)
        {
            return Result<UpdateTaskCommentsOutput>.NotFound();
        }

        var comment = new TaskComment(currentUser.ExternalIdentifier, input.Comment);

        task.AppendComment(comment);

        await _taskRepository.UpdateAsync(task, cancellationToken);

        return Result<UpdateTaskCommentsOutput>.NoContent();
    }
}
