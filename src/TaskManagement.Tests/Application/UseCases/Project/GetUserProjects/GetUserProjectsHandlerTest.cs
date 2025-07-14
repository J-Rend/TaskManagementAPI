using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Project.GetUserProjects;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Project.GetUserProjects;

public class GetUserProjectsHandlerTest
{
    private readonly Mock<IProjectRepository> projectRepository;

    public GetUserProjectsHandlerTest()
    {
        projectRepository = new Mock<IProjectRepository>();
    }

    [Fact]
    public async System.Threading.Tasks.Task GetUserProjectsHandler_DefaultFlow_ShouldPass()
    {
        string userId = Guid.NewGuid().ToString();

        var input = new GetUserProjectsInput(userId);

        var repositoryResult = new List<Domain.Entities.Internal.Project>()
        {
            ProjectArrangements.ValidProject
        };

        projectRepository
            .Setup(s => s.GetByUserIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(repositoryResult.AsEnumerable());

        var handler = new GetUserProjectsHandler(projectRepository.Object);

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.Success, result.Status);
    }
}
