using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Project.RemoveProject;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Project.RemoveProject;

public class RemoveProjectHandlerTest
{
    private readonly Mock<ITaskRepository> taskRepositoryMock;
    private readonly Mock<IProjectRepository> projectRepositoryMock;

    public RemoveProjectHandlerTest()
    {
        taskRepositoryMock = new Mock<ITaskRepository>();
        projectRepositoryMock = new Mock<IProjectRepository>();
    }

    private RemoveProjectHandler GenerateHandler()
    {
        return new RemoveProjectHandler(taskRepositoryMock.Object, projectRepositoryMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task RemoveProject_WhenProjectNotFound_ShouldReturnNotFound()
    {
        var input = new RemoveProjectInput(Guid.NewGuid().ToString());

        projectRepositoryMock
            .Setup(s => s.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((TaskManagement.Domain.Entities.Internal.Project)null);

        var handler = GenerateHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NotFound, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task RemoveProject_WhenProjectIsFound_ButContainsPendingTasks_ShouldReturnClientError()
    {
        var input = new RemoveProjectInput(Guid.NewGuid().ToString());

        projectRepositoryMock
            .Setup(s => s.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ProjectArrangements.ValidProject);

        taskRepositoryMock
            .Setup(s => s.GetTasksByProjectAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => [TaskArrangements.ValidPendingTask]);

        var handler = GenerateHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.ClientError, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task RemoveProject_WhenProjectIsFound_AndContainsNotPendingTasks_ShouldReturnNoContent()
    {
        var input = new RemoveProjectInput(Guid.NewGuid().ToString());

        projectRepositoryMock
            .Setup(s => s.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ProjectArrangements.ValidProject);

        taskRepositoryMock
            .Setup(s => s.GetTasksByProjectAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => [TaskArrangements.ValidFinishedTask]);

        projectRepositoryMock
            .Setup(s => s.UpdateAsync(It.IsAny<Domain.Entities.Internal.Project>(), It.IsAny<CancellationToken>()));

        var handler = GenerateHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NoContent, result.Status);
    }
}
