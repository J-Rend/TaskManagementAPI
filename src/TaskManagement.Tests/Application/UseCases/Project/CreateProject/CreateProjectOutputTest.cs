using TaskManagement.Application.DTO;
using TaskManagement.Application.UseCases.Project.CreateProject;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Project.CreateProject;

public class CreateProjectOutputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var projectEntity = ProjectArrangements.ValidProject;

        var projectDto = new TaskManagement.Application.DTO.Project(projectEntity);

        var output = new CreateProjectOutput(projectDto);

        Assert.Equal(projectDto,output.Project);
    }
}
