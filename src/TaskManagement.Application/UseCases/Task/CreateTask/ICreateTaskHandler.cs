using TaskManagement.Application.UseCases.Base;

namespace TaskManagement.Application.UseCases.Task.CreateTask;

public interface ICreateTaskHandler : IUseCaseHandler<CreateTaskInput, CreateTaskOutput>
{
}
