namespace TaskManagement.Application.DTO;

public class Project
{
    public string? Id { get; private set; }
    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public DateTime? RemovedAt { get; private set; }

    public string UserId { get; private set; }

    public Project(Domain.Entities.Internal.Project project)
    {
        Id = project.Id;
        Title = project.Title;
        Description = project.Description;
        RemovedAt = project.RemovedAt;
        UserId = project.UserId;
    }

}
