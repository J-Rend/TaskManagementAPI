using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Task.RemoveTask;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Task.RemoveTask;

public class RemoveTaskHandlerTest
{
    private readonly Mock<ITaskRepository> taskRepositoryMock;
    private readonly Mock<ICurrentUserService> currentUserServiceMock;

    public RemoveTaskHandlerTest()
    {
        taskRepositoryMock = new Mock<ITaskRepository>();
        currentUserServiceMock = new Mock<ICurrentUserService>();
    }

    private RemoveTaskHandler GenerateValidHandler()
    {
        return new RemoveTaskHandler(taskRepositoryMock.Object,currentUserServiceMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task RemoveTask_WhenTaskNotFound_ShouldReturnNotFound()
    {
        var input = new RemoveTaskInput("123");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser()).Returns(new Domain.Entities.External.User("123", "Admin"));

        taskRepositoryMock
            .Setup(s => s.GetTaskByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Domain.Entities.Internal.Task)null);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NotFound, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task RemoveTask_WhenTaskFounded_ShouldReturnNoContent()
    {
        var input = new RemoveTaskInput("123");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser()).Returns(new Domain.Entities.External.User("123", "Admin"));

        taskRepositoryMock
            .Setup(s => s.GetTaskByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(TaskArrangements.ValidFinishedTask);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NoContent, result.Status);
    }

}
