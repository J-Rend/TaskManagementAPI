namespace TaskManagement.Application.UseCases.Task.GetProjectTasks;

public sealed class GetProjectTasksOutput
{
    public string ProjectId { get; private set; }
    public IEnumerable<DTO.Task> Tasks { get; private set; }

    public GetProjectTasksOutput(string projectId, IEnumerable<DTO.Task> projects)
    {
        ProjectId = projectId;
        Tasks = projects;
    }
}
