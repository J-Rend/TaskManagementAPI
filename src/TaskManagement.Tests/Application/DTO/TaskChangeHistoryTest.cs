using TaskManagement.Domain.ValueObjects;

namespace TaskManagement.Tests.Application.DTO;

public class TaskChangeHistoryTest
{
    [Fact]
    public void TaskChangeHistory_ShouldInitializePropertiesCorrectly()
    {
        var currentDate = DateTime.Now;
        // Arrange
        var taskChangeHistory = new TaskChangeHistory("Test", currentDate, "Teste123","OldValue","NewValue");

        // Act
        var dto = new TaskManagement.Application.DTO.TaskChangeHistory(taskChangeHistory!);

        // Assert
        Assert.Equal("Test", dto.FieldName);
        Assert.Equal(dto.ChangedAt,currentDate);
        Assert.Equal("Teste123", dto.ModifiedBy);
        Assert.Equal("OldValue", dto.OldValue);
        Assert.Equal("NewValue", dto.NewValue);
    }
}
