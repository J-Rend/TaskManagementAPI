namespace TaskManagement.Application.DTO;

public class Project
{
    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public DateTime? RemovedAt { get; private set; }

    public string UserId { get; private set; }

    public Project(Domain.Entities.Internal.Project project)
    {
        Title = project.Title;
        Description = project.Description;
        RemovedAt = project.RemovedAt;
        UserId = project.UserId;
    }

}
