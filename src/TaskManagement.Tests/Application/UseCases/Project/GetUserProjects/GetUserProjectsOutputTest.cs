using TaskManagement.Application.UseCases.Project.GetUserProjects;

namespace TaskManagement.Tests.Application.UseCases.Project.GetUserProjects;

public class GetUserProjectsOutputTest
{
    [Fact]
    public void GetUserProjectsOutput_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var userId = "TestUserId";
        var projectName = "TestProjectName";
        var projectDescription = "TestProjectDescription";

        var project = TaskManagement.Domain.Entities.Internal.Project.Generate(projectName, projectDescription, userId, out _);
        // Act
        var output = new GetUserProjectsOutput(userId, [new(project!)]);

        // Assert
        Assert.Equal(userId, output.UserId);
        Assert.Equal(projectName, output.Projects.First().Title);
        Assert.Equal(projectDescription, output.Projects.First().Description);
    }
}
