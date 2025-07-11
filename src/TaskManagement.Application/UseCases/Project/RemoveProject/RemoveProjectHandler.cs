using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Project.RemoveProject;

public class RemoveProjectHandler : IRemoveProjectHandler
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public RemoveProjectHandler(ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        ArgumentNullException.ThrowIfNull(taskRepository);
        ArgumentNullException.ThrowIfNull(projectRepository);

        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Result<RemoveProjectOutput>> ExecuteAsync(RemoveProjectInput input, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(input.ProjectId, cancellationToken);

        if (project is null)
        {
            return Result<RemoveProjectOutput>.NotFound();
        }

        var projectTasks = await _taskRepository.GetTasksByProject(input.ProjectId, cancellationToken);

        var pendingTasks = projectTasks
                            .Where(t => t.Status == Domain.Enums.TaskStatus.Pending)
                            .ToList();

        if (pendingTasks.Any())
        {
            return Result<RemoveProjectOutput>.ClientError(
                [new("The project cannot be removed because it has pending tasks. Please complete, remove or finish the tasks before removing the project.")]
            );
        }

        project.Remove();

        await _projectRepository.UpdateAsync(project, cancellationToken);

        return Result<RemoveProjectOutput>.NoContent();
    }
}
