namespace TaskManagement.Application.DTO;

public class TaskComment
{
    public TaskComment(Domain.ValueObjects.TaskComment taskComment)
    {
        UserId = taskComment.UserId;
        Comment = taskComment.Comment;
    }

    public string UserId { get; private set; }

    public string Comment { get; private set; }
}
