namespace TaskManagement.Application.UseCases.Project.RemoveProject;

public sealed class RemoveProjectInput
{
    public RemoveProjectInput(string projectId)
    {
        ProjectId = projectId;
    }

    public string ProjectId { get; private set; }
}
