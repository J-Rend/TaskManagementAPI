using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Reports.TaskReportByUser;

public class TaskReportByUserHandler : ITaskReportByUserHandler
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;

    public TaskReportByUserHandler(
        ICurrentUserService currentUserService, 
        IProjectRepository projectRepository, 
        ITaskRepository taskRepository)
    {
        ArgumentNullException.ThrowIfNull(currentUserService);
        ArgumentNullException.ThrowIfNull(projectRepository);
        ArgumentNullException.ThrowIfNull(taskRepository);

        _currentUserService = currentUserService;
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
    }

    public async Task<Result<TaskReportByUserOutput>> ExecuteAsync(TaskReportByUserInput input, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        var userProjects = await _projectRepository.GetByUserIdAsync(input.UserIdentifier, cancellationToken);

        if (!userProjects.Any())
        {
            return Result<TaskReportByUserOutput>.ClientError([new("There is no projects associated to given user.")]);
        }

        var projectIds = userProjects.Select(p => p.Id);

        var tasks = await _taskRepository.GetTasksByProjectListAsync(projectIds, cancellationToken);

        var output = new TaskReportByUserOutput(input.StartDate, input.EndDate, input.UserIdentifier,tasks);

        return Result<TaskReportByUserOutput>.Success(output);
    }
}
