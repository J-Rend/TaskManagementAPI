namespace TaskManagement.Application.UseCases.Task.CreateTask;

public class CreateTaskInput
{
    public CreateTaskInput(string title, string description, DateTime dueDate, string status, string priority, string? projectId)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Priority = priority;
        ProjectId = projectId;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime DueDate { get; private set; }

    public string Status { get; private set; }

    public string Priority { get; private set; }

    public string? ProjectId { get; private set; }
}
