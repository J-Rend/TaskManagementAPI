using TaskManagement.Application.UseCases.Project.GetUserProjects;

namespace TaskManagement.Tests.Application.UseCases.Project.GetUserProjects;

public class GetUserProjectsInputTest
{
    [Fact]
    public void GetUserProjectsInput_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var userId = "TestUserId";

        // Act
        var input = new GetUserProjectsInput(userId);

        // Assert
        Assert.Equal(userId, input.UserId);
    }
}
