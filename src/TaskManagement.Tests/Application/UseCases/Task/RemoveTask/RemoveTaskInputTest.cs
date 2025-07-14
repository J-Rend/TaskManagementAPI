using TaskManagement.Application.UseCases.Task.RemoveTask;

namespace TaskManagement.Tests.Application.UseCases.Task.RemoveTask;

public class RemoveTaskInputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var taskId = Guid.NewGuid().ToString();
        var input = new RemoveTaskInput(taskId);

        Assert.Equal(taskId, input.TaskId);
    }
}
