using TaskManagement.Domain.Entities.Internal;

namespace TaskManagement.Tests.Application.DTO;

public class ProjectTest
{
    [Fact]
    public void Project_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var project = Project.Generate(
            title: "Test Project",
            description: "This is a test project.",
            userId: "user123",
            out var validationResults
        );

        // Act
        var dto = new TaskManagement.Application.DTO.Project(project!);

        // Assert
        Assert.Equal("Test Project", dto.Title);
        Assert.Equal("This is a test project.", dto.Description);
        Assert.Null(dto.RemovedAt);
        Assert.Equal("user123", dto.UserId);
    }
}
