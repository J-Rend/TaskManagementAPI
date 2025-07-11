using TaskManagement.Application.UseCases.Base;

namespace TaskManagement.Application.UseCases.Task.RemoveTask;

public interface IRemoveTaskHandler : IUseCaseHandler<RemoveTaskInput, RemoveTaskOutput>
{
}
