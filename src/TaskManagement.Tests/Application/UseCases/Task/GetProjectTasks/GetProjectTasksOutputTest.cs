using TaskManagement.Application.UseCases.Task.GetProjectTasks;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Task.GetProjectTasks;

public class GetProjectTasksOutputTest
{
    [Fact]
    public void GetProjectTasksOutput_Should_Initialize_With_Empty_Tasks()
    {
        string projectId = Guid.NewGuid().ToString();
        var tasksDto = new List<TaskManagement.Application.DTO.Task>()
        {
            new TaskManagement.Application.DTO.Task(TaskArrangements.ValidPendingTask)
        };
        // Arrange & Act
        var output = new GetProjectTasksOutput(projectId, tasksDto);

        // Assert
        Assert.NotEmpty(output.Tasks);
        Assert.Equal(projectId, output.ProjectId);
        Assert.Equal(tasksDto,output.Tasks);
    }
}
