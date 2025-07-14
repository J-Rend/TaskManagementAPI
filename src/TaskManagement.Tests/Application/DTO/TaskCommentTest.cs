using TaskManagement.Domain.ValueObjects;

namespace TaskManagement.Tests.Application.DTO;

public class TaskCommentTest
{
    [Fact]
    public void TaskComment_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var taskComment = new TaskComment("Teste123","TestComment");

        // Act
        var dto = new TaskManagement.Application.DTO.TaskComment(taskComment!);

        // Assert
        Assert.Equal("TestComment", dto.Comment);
        Assert.Equal("Teste123", dto.UserId);
    }
}
