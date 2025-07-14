namespace TaskManagement.Application.UseCases.Project.CreateProject;

public sealed class CreateProjectOutput
{
    public CreateProjectOutput(DTO.Project project)
    {
        Project = project;
    }

    public DTO.Project Project { get; private set; }
}
