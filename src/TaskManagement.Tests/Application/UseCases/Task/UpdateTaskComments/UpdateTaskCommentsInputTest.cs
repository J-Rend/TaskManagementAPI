using TaskManagement.Application.UseCases.Task.UpdateTaskComments;

namespace TaskManagement.Tests.Application.UseCases.Task.UpdateTaskComments;

public class UpdateTaskCommentsInputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var taskId = Guid.NewGuid().ToString();
        var comment = "Test Comment";

        var input = new UpdateTaskCommentsInput(taskId, comment);

        Assert.Equal(taskId, input.TaskId);
        Assert.Equal(comment, input.Comment);
    }
}
