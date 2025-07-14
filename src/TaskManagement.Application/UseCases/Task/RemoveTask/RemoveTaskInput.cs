namespace TaskManagement.Application.UseCases.Task.RemoveTask;

public sealed class RemoveTaskInput
{
    public string TaskId { get; private set; }

    public RemoveTaskInput(string taskId)
    {
        TaskId = taskId;
    }

}
