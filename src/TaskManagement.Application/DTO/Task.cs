namespace TaskManagement.Application.DTO;

public class Task
{
    public Task(Domain.Entities.Internal.Task task)
    {
        Id = task.Id;
        Title = task.Title;
        Description = task.Description;
        DueDate = task.DueDate;
        Status = task.Status.ToString();
        Priority = task.Priority.ToString();
        ProjectId = task.ProjectId;
        Comments = task.Comments.Select(s => new TaskComment(s));
        ChangeHistory = task.ChangeHistory.Select(s => new TaskChangeHistory(s));
    }

    public string Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime DueDate { get; private set; }

    public string Status { get; private set; }

    public string Priority { get; private set; }

    public string? ProjectId { get; private set; }

    public IEnumerable<TaskComment> Comments { get; private set; }

    public IEnumerable<TaskChangeHistory> ChangeHistory { get; private set; }
}
