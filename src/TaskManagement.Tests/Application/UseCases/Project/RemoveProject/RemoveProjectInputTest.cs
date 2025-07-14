namespace TaskManagement.Tests.Application.UseCases.Project.RemoveProject;

public class RemoveProjectInputTest
{
    [Fact]
    public void RemoveProjectInput_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var projectId = "TestProjectId";

        // Act
        var input = new TaskManagement.Application.UseCases.Project.RemoveProject.RemoveProjectInput(projectId);

        // Assert
        Assert.Equal(projectId, input.ProjectId);
    }
}
