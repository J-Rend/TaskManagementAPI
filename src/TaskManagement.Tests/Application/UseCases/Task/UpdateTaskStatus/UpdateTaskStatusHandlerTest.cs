using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Task.UpdateTaskStatus;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Task.UpdateTaskStatus;

public class UpdateTaskStatusHandlerTest
{
    private readonly Mock<ITaskRepository> taskRepositoryMock;
    private readonly Mock<ICurrentUserService> currentUserServiceMock;

    public UpdateTaskStatusHandlerTest()
    {
        taskRepositoryMock = new Mock<ITaskRepository>();
        currentUserServiceMock = new Mock<ICurrentUserService>();
    }

    private UpdateTaskStatusHandler GenerateValidHandler()
    {
        return new UpdateTaskStatusHandler(taskRepositoryMock.Object,currentUserServiceMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateTaskStatus_WhenTaskIsNull_ShouldReturnNotFound()
    {
        var input = new UpdateTaskStatusInput("123", "Finished");

        taskRepositoryMock
            .Setup(s => s.GetTaskByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Domain.Entities.Internal.Task)null);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NotFound, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateTaskStatus_WhenNewTaskStatusIsInvalid_ShouldReturnClientError()
    {
        var input = new UpdateTaskStatusInput("123", "Invalid");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser())
            .Returns(new Domain.Entities.External.User("123", "Admin"));

        taskRepositoryMock
            .Setup(s => s.GetTaskByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(TaskArrangements.ValidPendingTask);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.ClientError, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateTaskStatus_WhenNewTaskStatusIsValid_ShouldReturnNoContent()
    {
        var input = new UpdateTaskStatusInput("123", "Finished");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser())
            .Returns(new Domain.Entities.External.User("123", "Admin"));

        taskRepositoryMock
            .Setup(s => s.GetTaskByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(TaskArrangements.ValidPendingTask);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.NoContent, result.Status);
    }
}
