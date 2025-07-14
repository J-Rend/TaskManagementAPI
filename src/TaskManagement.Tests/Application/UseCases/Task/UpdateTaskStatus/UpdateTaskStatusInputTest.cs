using TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

namespace TaskManagement.Tests.Application.UseCases.Task.UpdateTaskStatus;

public class UpdateTaskStatusInputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        string taskId = Guid.NewGuid().ToString();
        string status = "Pending";

        var input = new UpdateTaskStatusInput(taskId,status);

        Assert.Equal(status,input.Status);
        Assert.Equal(taskId, input.TaskId);
    }
}
