namespace TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

public sealed class UpdateTaskStatusInput
{
    public string TaskId { get; private set; }

    public string Status { get; private set; }

    public UpdateTaskStatusInput(string taskId, string status)
    {
        TaskId = taskId;
        Status = status;
    }
}
