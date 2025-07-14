using TaskManagement.Application.UseCases.Task.CreateTask;

namespace TaskManagement.Tests.Application.UseCases.Task.CreateTask;

public class CreateTaskInputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var currentDate = DateTime.Now;

        var input = new CreateTaskInput("TestTitle","TestDescription", currentDate,"Pending","High","teste123");

        Assert.Equal("TestTitle",input.Title);
        Assert.Equal("TestDescription", input.Description);
        Assert.Equal(currentDate, input.DueDate);
        Assert.Equal("Pending",input.Status);
        Assert.Equal("High", input.Priority);
        Assert.NotNull(input.ProjectId);
        Assert.Equal("teste123", input.ProjectId);

    }
}
