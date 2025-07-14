namespace TaskManagement.Application.UseCases.Project.CreateProject;

public sealed class CreateProjectInput
{
    public CreateProjectInput(string? title, string? description)
    {
        Title = title;
        Description = description;
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
}
