namespace TaskManagement.Application.UseCases.Project.CreateProject;

public class CreateProjectOutput
{
    public CreateProjectOutput(DTO.Project project)
    {
        Project = project;
    }

    public DTO.Project Project { get; private set; }
}
