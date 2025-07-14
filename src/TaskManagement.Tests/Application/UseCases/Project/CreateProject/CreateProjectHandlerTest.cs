using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Project.CreateProject;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Tests.Application.UseCases.Project.CreateProject;

public class CreateProjectHandlerTest
{
    private readonly Mock<IProjectRepository> projectRepositoryMock;
    private readonly Mock<ICurrentUserService> currentUserServiceMock;

    public CreateProjectHandlerTest()
    {
        projectRepositoryMock = new Mock<IProjectRepository>();
        currentUserServiceMock = new Mock<ICurrentUserService>();
    }

    private CreateProjectHandler GenerateHandler()
    {
        return new CreateProjectHandler(projectRepositoryMock.Object, currentUserServiceMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task WhenAnyErrorExistsOnEntityCreation_ShouldReturnResultError()
    {
        var input = new CreateProjectInput("teste", "tst_description");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser())
            .Returns(new TaskManagement.Domain.Entities.External.User("","teste"));

        var handler = GenerateHandler();

        var result = await handler.ExecuteAsync(input,CancellationToken.None);

        Assert.Equal(ResultStatus.ClientError, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task WhenNoErrorsExists_ShouldReturnSuccess()
    {
        var input = new CreateProjectInput("teste", "teste");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser())
            .Returns(new TaskManagement.Domain.Entities.External.User("teste", "teste"));

        projectRepositoryMock
            .Setup(s => s.CreateProjectAsync(It.IsAny<TaskManagement.Domain.Entities.Internal.Project>(), It.IsAny<CancellationToken>()));

        var handler = GenerateHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.Created, result.Status);
    }
}
