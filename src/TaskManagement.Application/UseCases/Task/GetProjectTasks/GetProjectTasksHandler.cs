using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Task.GetProjectTasks;

public class GetProjectTasksHandler : IGetProjectTasksHandler
{
    private readonly ITaskRepository _taskRepository;

    public GetProjectTasksHandler(ITaskRepository taskRepository)
    {
        ArgumentNullException.ThrowIfNull(taskRepository);

        _taskRepository = taskRepository;
    }

    public async Task<Result<GetProjectTasksOutput>> ExecuteAsync(GetProjectTasksInput input, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasksByProject(input.ProjectId, cancellationToken);

        var tasksDto = tasks.Select(t => new DTO.Task(t));

        var output = new GetProjectTasksOutput(input.ProjectId, tasksDto);

        return Result<GetProjectTasksOutput>.Success(output);
    }
}
