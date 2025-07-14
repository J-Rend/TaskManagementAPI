using TaskManagement.Application.UseCases.Project.CreateProject;

namespace TaskManagement.Tests.Application.UseCases.Project.CreateProject;

public class CreateProjectInputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var input = new CreateProjectInput("tst", "tst_description");

        Assert.NotNull(input);
        Assert.Equal("tst", input.Title);
        Assert.Equal("tst_description", input.Description);
    }
}
