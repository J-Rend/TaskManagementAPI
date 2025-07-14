using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Reports.TaskReportByUser;
using TaskManagement.Domain.Interfaces.Infrastructure.Permissioning;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Reports.TaskReportByUser;

public class TaskReportByUserHandlerTest
{
    private Mock<ICurrentUserService> currentUserServiceMock;
    private Mock<ITaskRepository> taskRepositoryMock;
    private Mock<IProjectRepository> projectRepositoryMock;

    public TaskReportByUserHandlerTest()
    {
        currentUserServiceMock = new Mock<ICurrentUserService>();
        taskRepositoryMock = new Mock<ITaskRepository>();
        projectRepositoryMock = new Mock<IProjectRepository>();
    }

    private TaskReportByUserHandler GenerateValidHandler()
    {
        return new TaskReportByUserHandler(
            currentUserServiceMock.Object, 
            projectRepositoryMock.Object,
            taskRepositoryMock.Object
            );
    }

    [Fact]
    public async System.Threading.Tasks.Task GenerateReport_WhenThereIsNoTaskForUser_ShouldReturnClientError()
    {
        var input = new TaskReportByUserInput(DateTime.Now, DateTime.Now, "teste123");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser())
            .Returns(new Domain.Entities.External.User("123", "Admin"));

        projectRepositoryMock
            .Setup(s => s.GetByUserIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.ClientError, result.Status);
    }

    [Fact]
    public async System.Threading.Tasks.Task GenerateReport_WhenThereIsTaskForUser_ShouldReturnSuccess()
    {
        var input = new TaskReportByUserInput(DateTime.Now, DateTime.Now, "teste123");

        currentUserServiceMock
            .Setup(s => s.GetCurrentUser())
            .Returns(new Domain.Entities.External.User("123", "Admin"));

        projectRepositoryMock
            .Setup(s => s.GetByUserIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([ProjectArrangements.ValidProject]);

        taskRepositoryMock
            .Setup(s => s.GetTasksByProjectListAsync(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([TaskArrangements.ValidInProgressTask]);

        var handler = GenerateValidHandler();

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.Success, result.Status);
    }
}
