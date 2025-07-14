using TaskManagement.Application.DTO;
using TaskManagement.Application.UseCases.Task.CreateTask;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Task.CreateTask;

public class CreateTaskOutputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var taskDto = new TaskManagement.Application.DTO.Task(TaskArrangements.ValidPendingTask);

        var output = new CreateTaskOutput(taskDto);

        Assert.Equal(taskDto, output.Task);
    }
}
