namespace TaskManagement.Application.UseCases.Task.GetProjectTasks;

public class GetProjectTasksInput
{
    public GetProjectTasksInput(string projectId)
    {
        ProjectId = projectId;
    }

    public string ProjectId { get; private set; }
}
