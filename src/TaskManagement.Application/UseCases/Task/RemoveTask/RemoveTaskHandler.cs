using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Task.RemoveTask;

public class RemoveTaskHandler : IRemoveTaskHandler
{
    private readonly ITaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public RemoveTaskHandler(ITaskRepository taskRepository, ICurrentUserService currentUserService)
    {
        ArgumentNullException.ThrowIfNull(taskRepository);
        ArgumentNullException.ThrowIfNull(currentUserService);

        _currentUserService = currentUserService;
        _taskRepository = taskRepository;
    }

    public async Task<Result<RemoveTaskOutput>> ExecuteAsync(RemoveTaskInput input, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        var task = await _taskRepository.GetTaskByIdAsync(input.TaskId, cancellationToken);

        if (task is null)
        {
            return Result<RemoveTaskOutput>.NotFound();
        }

        task.RemoveFromProject(currentUser.ExternalIdentifier);

        await _taskRepository.UpdateAsync(task, cancellationToken);

        return Result<RemoveTaskOutput>.NoContent();
    }
}
