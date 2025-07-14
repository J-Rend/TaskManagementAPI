using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Task.CreateTask;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;

namespace TaskManagement.Tests.Application.UseCases.Task.CreateTask;

public class CreateTaskHandlerTest
{
    private Mock<ITaskRepository> taskRepositoryMock;

    public CreateTaskHandlerTest()
    {
        taskRepositoryMock = new Mock<ITaskRepository>();
    }

    private CreateTaskHandler GenerateValidHandler()
    {
        return new CreateTaskHandler(taskRepositoryMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task CreateTask_WhenTaskIsInvalid_ShouldReturnClientError()
    {
        var input = new CreateTaskInput("","TestDescription",DateTime.Now.AddDays(1),"Pending","High","123");

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.ClientError,result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task CreateTask_WhenProjectIdNotGiven_ShouldSkipFromTaskCountingValidation_AndReturnCreated()
    {
        var input = new CreateTaskInput("TestTitle", "TestDescription", DateTime.Now.AddDays(1), "Pending", "High", string.Empty);

        taskRepositoryMock
            .Setup(s => s.CreateAsync(It.IsAny<Domain.Entities.Internal.Task>(), It.IsAny<CancellationToken>()));

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.Created, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task CreateTask_WhenTaskQuantityExceedsLimit_ShouldExecuteTaskCountingValidation_AndReturnFail()
    {
        var input = new CreateTaskInput("TestTitle", "TestDescription", DateTime.Now.AddDays(1), "Pending", "High", "abc123");

        taskRepositoryMock
            .Setup(s => s.CreateAsync(It.IsAny<Domain.Entities.Internal.Task>(), It.IsAny<CancellationToken>()));

        taskRepositoryMock
            .Setup(s => s.CountTasksByProjectAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(20);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.ClientError, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task CreateTask_WhenProjectIdGiven_AndTasksDontExceedsLimit_ShouldExecuteTaskCountingValidation_AndReturnCreated()
    {
        var input = new CreateTaskInput("TestTitle", "TestDescription", DateTime.Now.AddDays(1), "Pending", "High", "abc123");

        taskRepositoryMock
            .Setup(s => s.CreateAsync(It.IsAny<Domain.Entities.Internal.Task>(), It.IsAny<CancellationToken>()));

        taskRepositoryMock
            .Setup(s => s.CountTasksByProjectAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(0);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.Created, result.Status);
    }
}
