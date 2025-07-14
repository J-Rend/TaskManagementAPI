using Moq;
using TaskManagement.Application.Output;
using TaskManagement.Application.UseCases.Project.GetUserProjects;
using TaskManagement.Application.UseCases.Task.GetProjectTasks;
using TaskManagement.Domain.Interfaces.Infrastructure.Repositories;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Task.GetProjectTasks;

public class GetProjectTasksHandlerTest
{
    private readonly Mock<ITaskRepository> taskRepositoryMock;

    public GetProjectTasksHandlerTest()
    {
        taskRepositoryMock = new Mock<ITaskRepository>();
    }

    [Fact]
    public async System.Threading.Tasks.Task GetProjectTasksHandler_DefaultFlow_ShouldPass()
    {
        var input = new GetProjectTasksInput(Guid.NewGuid().ToString());

        var repositoryResult = new List<Domain.Entities.Internal.Task>()
        {
            TaskArrangements.ValidPendingTask
        };

        taskRepositoryMock
            .Setup(s => s.GetTasksByProjectAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(repositoryResult.AsEnumerable());

        var handler = new GetProjectTasksHandler(taskRepositoryMock.Object);

        var result = await handler.ExecuteAsync(input, CancellationToken.None);

        Assert.Equal(ResultStatus.Success, result.Status);
    }

}
