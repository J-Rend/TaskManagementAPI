using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

public class UpdateTaskStatusHandler : IUpdateTaskStatusHandler
{
    private readonly ITaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateTaskStatusHandler(ITaskRepository taskRepository, ICurrentUserService currentUserService)
    {
        ArgumentNullException.ThrowIfNull(taskRepository);
        ArgumentNullException.ThrowIfNull(currentUserService);

        _currentUserService = currentUserService;
        _taskRepository = taskRepository;
    }

    public async Task<Result<UpdateTaskStatusOutput>> ExecuteAsync(UpdateTaskStatusInput input, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        var task = await _taskRepository.GetTaskByIdAsync(input.TaskId, cancellationToken);

        if (task is null)
        {
            
            return Result<UpdateTaskStatusOutput>.NotFound();
        }

        task.UpdateStatus(input.Status, currentUser.ExternalIdentifier, out var validationResults);

        if (validationResults.Any())
        {
            
            return Result<UpdateTaskStatusOutput>.ClientError(validationResults);
        }

        await _taskRepository.UpdateAsync(task, cancellationToken);

        
        return Result<UpdateTaskStatusOutput>.NoContent();
    }
}
