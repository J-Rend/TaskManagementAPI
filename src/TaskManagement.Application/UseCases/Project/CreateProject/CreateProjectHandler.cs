using TaskManagement.Application.Output;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Application.UseCases.Project.CreateProject;

public class CreateProjectHandler : ICreateProjectHandler
{
    private readonly IProjectRepository _projectRepository;
    private readonly ICurrentUserService _currentUserService;

    public CreateProjectHandler(IProjectRepository projectRepository, ICurrentUserService currentUserService)
    {
        ArgumentNullException.ThrowIfNull(projectRepository);
        ArgumentNullException.ThrowIfNull(currentUserService);

        _currentUserService = currentUserService;
        _projectRepository = projectRepository;
    }

    public async Task<Result<CreateProjectOutput>> ExecuteAsync(CreateProjectInput input, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        var project = Domain.Entities.Internal.Project.Generate(input.Title, input.Description, currentUser.ExternalIdentifier, out var validationResults);

        if (project is null)
        {
            return Result<CreateProjectOutput>.ClientError(validationResults);
        }

        await _projectRepository.CreateProjectAsync(project, cancellationToken);

        var output = new CreateProjectOutput(new(project));

        var uri = $"/api/projects/{project.Id}";

        return Result<CreateProjectOutput>.Created(output, uri);
    }
}
