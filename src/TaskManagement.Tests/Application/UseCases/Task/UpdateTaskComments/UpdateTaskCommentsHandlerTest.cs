using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Task.UpdateTaskComments;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Task.UpdateTaskComments;

public class UpdateTaskCommentsHandlerTest
{
    private readonly Mock<ITaskRepository> taskRepositoryMock;
    private readonly Mock<ICurrentUserService> currentUserServiceMock;

    public UpdateTaskCommentsHandlerTest()
    {
        taskRepositoryMock = new Mock<ITaskRepository>();
        currentUserServiceMock = new Mock<ICurrentUserService>();
    }

    private UpdateTaskCommentsHandler GenerateValidHandler()
    {
        return new UpdateTaskCommentsHandler(taskRepositoryMock.Object,currentUserServiceMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateTaskComments_WhenTaskIsNull_ShouldReturnNotFound()
    {
        var input = new UpdateTaskCommentsInput("123", "teste");

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
    public async System.Threading.Tasks.Task UpdateTaskComments_WhenTaskIsNotNull_ShouldReturnNoContent()
    {
        var input = new UpdateTaskCommentsInput("123", "teste");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser()).Returns(new Domain.Entities.External.User("123", "Admin"));

        taskRepositoryMock
            .Setup(s => s.GetTaskByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(TaskArrangements.ValidPendingTask);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NoContent, result.Status);
    }
}
