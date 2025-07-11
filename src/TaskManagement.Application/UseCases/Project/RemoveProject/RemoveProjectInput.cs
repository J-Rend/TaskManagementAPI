namespace TaskManagement.Application.UseCases.Project.RemoveProject;

public class RemoveProjectInput
{
    public RemoveProjectInput(string projectId)
    {
        ProjectId = projectId;
    }

    public string ProjectId { get; private set; }
}
