using TaskManagement.Application.UseCases.Base;

namespace TaskManagement.Application.UseCases.Task.GetProjectTasks;

public interface IGetProjectTasksHandler : IUseCaseHandler<GetProjectTasksInput, GetProjectTasksOutput>
{
}
