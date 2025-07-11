namespace TaskManagement.Application.UseCases.GetUserProjects;

public class GetUserProjectsInput
{
    public string UserId { get; private set; }

    public GetUserProjectsInput(string userId)
    {
        UserId = userId;
    }
}
