using TaskManagement.Domain.Entities.Internal;

namespace TeskManagement.Tests.Domain.Entities.Internal;

public class ProjectTests
{
    [Fact]
    public void WhenEverythingIsFine_ShouldPass()
    {
        // Arrange
        var projectTitle = "Test Project";
        var projectDescription = "This is a test project.";
        var userId = Guid.NewGuid().ToString();

        // Act
        var project = Project.Generate(projectTitle,projectDescription,userId,out var validationResults);

        // Assert
        Assert.NotNull(project);
        Assert.Equal(userId, project.UserId);
        Assert.Equal(projectTitle, project.Title);
        Assert.Equal(projectDescription, project.Description);
        Assert.Empty(validationResults);
    }

    [Fact]
    public void WhenUserIdIsEmpty_ShouldReturnValidationResultError()
    {
        // Arrange
        var projectTitle = "Test Project";
        var projectDescription = "This is a test project.";
        var userId = "";

        // Act
        var project = Project.Generate(projectTitle, projectDescription, userId, out var validationResults);

        // Assert
        Assert.Null(project);
        Assert.NotEmpty(validationResults);
        Assert.Contains(validationResults, v => v.ErrorMessage == "UserId is required.");
    }

    [Fact]
    public void WhenProjectAreRemoved_RemovedAtShouldNotBeNull()
    {
        // Arrange
        var projectTitle = "Test Project";
        var projectDescription = "This is a test project.";
        var userId = Guid.NewGuid().ToString();

        // Act
        var project = Project.Generate(projectTitle, projectDescription, userId, out var validationResults);

        Assert.NotNull(project);
        Assert.Null(project.RemovedAt);

        project.Remove();

        // Assert
        Assert.Empty(validationResults);
        Assert.NotNull(project.RemovedAt);
    }
}
