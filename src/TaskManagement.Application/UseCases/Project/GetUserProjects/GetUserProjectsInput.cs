namespace TaskManagement.Application.UseCases.Project.GetUserProjects;

public class GetUserProjectsInput
{
    public string UserId { get; private set; }

    public GetUserProjectsInput(string userId)
    {
        UserId = userId;
    }
}
