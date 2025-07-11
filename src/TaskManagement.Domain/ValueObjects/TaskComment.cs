namespace TaskManagement.Domain.ValueObjects;

public class TaskComment
{
    public string UserId { get; private set; }

    public string Comment { get; private set; }

    public TaskComment(string userId, string comment)
    {
        UserId = userId;
        Comment = comment;
    }
}
