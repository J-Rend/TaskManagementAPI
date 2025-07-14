namespace TaskManagement.Tests.Application.DTO;

public class TaskTest
{
    [Fact]
    public void Task_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var task = TaskManagement.Domain.Entities.Internal.Task.Generate(
            "Test Title","Test Description",DateTime.Now.AddDays(1),"Pending","High",null,out var validationResults
        );

        // Act
        var dto = new TaskManagement.Application.DTO.Task(task!);

        // Assert
        Assert.Equal("Test Title", dto.Title);
        Assert.Equal("Test Description", dto.Description);
        Assert.Equal("Pending", dto.Status);
        Assert.Equal("High", dto.Priority);
    }
}
