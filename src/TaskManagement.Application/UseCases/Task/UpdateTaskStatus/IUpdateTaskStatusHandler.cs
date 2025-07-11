using TaskManagement.Application.UseCases.Base;

namespace TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

public interface IUpdateTaskStatusHandler : IUseCaseHandler<UpdateTaskStatusInput, UpdateTaskStatusOutput>
{
}
