namespace TaskManagement.Application.UseCases.Task.UpdateTaskComments;

public class UpdateTaskCommentsInput
{
    public string TaskId { get; private set; }

    public string Comment { get; private set; }

    public UpdateTaskCommentsInput(string taskId, string comment)
    {
        TaskId = taskId;
        Comment = comment;
    }
}
