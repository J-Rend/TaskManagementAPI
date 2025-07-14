using TaskManagement.Application.UseCases.Task.GetProjectTasks;

namespace TaskManagement.Tests.Application.UseCases.Task.GetProjectTasks;

public class GetProjectTasksInputTest
{
    [Fact]
    public void GetProjectTasksInput_ShouldHaveExpectedProperties()
    {
        var projectId = Guid.NewGuid().ToString();
        var input = new GetProjectTasksInput(projectId);

        Assert.Equal(projectId, input.ProjectId);
    }
}
