namespace TaskManagement.Application.UseCases.GetUserProjects;

public class GetUserProjectsOutput
{
    public string UserId { get; private set; }
    public IEnumerable<DTO.Project> Projects { get; private set; }

    public GetUserProjectsOutput(string userId, IEnumerable<DTO.Project> projects)
    {
        UserId = userId;
        Projects = projects;
    }
}
