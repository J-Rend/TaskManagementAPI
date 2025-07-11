namespace TaskManagement.Application.UseCases.Task.CreateTask;

public class CreateTaskOutput
{
    public CreateTaskOutput(DTO.Task task)
    {
        Task = task;
    }

    public DTO.Task Task { get; private set; }
}
