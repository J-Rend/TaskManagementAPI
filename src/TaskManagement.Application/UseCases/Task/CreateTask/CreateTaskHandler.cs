using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Task.CreateTask;

public class CreateTaskHandler : ICreateTaskHandler
{
    private readonly ITaskRepository _taskRepository;
    private readonly int MAX_TASKS_PER_PROJECT = 20;

    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        ArgumentNullException.ThrowIfNull(taskRepository);

        _taskRepository = taskRepository;
    }

    public async Task<Result<CreateTaskOutput>> ExecuteAsync(CreateTaskInput input, CancellationToken cancellationToken)
    {
        var task = Domain.Entities.Internal.Task.Generate(
            input.Title,
            input.Description,
            input.DueDate,
            input.Status,
            input.Priority,
            input.ProjectId,
            out var validationResults
            );

        if (task is null)
        {
            return Result<CreateTaskOutput>.ClientError(validationResults);
        }

        if (!string.IsNullOrWhiteSpace(input.ProjectId))
        {
            var tasksByProject = await _taskRepository.GetTasksByProject(input.ProjectId, cancellationToken);

            if (tasksByProject.Count() >= MAX_TASKS_PER_PROJECT)
            {
                string errorMessage = $"It's not possible to add more tasks to this project. It exceeds the limit of {MAX_TASKS_PER_PROJECT} tasks.";

                return Result<CreateTaskOutput>.ClientError([new(errorMessage)]);
            }
        }

        await _taskRepository.CreateAsync(task, cancellationToken);

        var output = new CreateTaskOutput(new(task));

        var resourcePath = $"/api/tasks/{task.Id}";

        return Result<CreateTaskOutput>.Created(output, resourcePath);
    }
}
