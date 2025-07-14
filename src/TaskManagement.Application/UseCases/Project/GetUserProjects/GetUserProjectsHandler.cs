using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Project.GetUserProjects;

public class GetUserProjectsHandler : IGetUserProjectsHandler
{
    private readonly IProjectRepository _projectRepository;

    public GetUserProjectsHandler(IProjectRepository projectRepository)
    {
        ArgumentNullException.ThrowIfNull(projectRepository);

        _projectRepository = projectRepository;
    }

    public async Task<Result<GetUserProjectsOutput>> ExecuteAsync(GetUserProjectsInput input, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetByUserIdAsync(input.UserId, cancellationToken);

        var projectsDto = projects.Select(s => new DTO.Project(s));

        var output = new GetUserProjectsOutput(input.UserId, projectsDto);

        
        return Result<GetUserProjectsOutput>.Success(output);
    }
}
