using TaskManagement.Domain.Enums;
using TaskManagement.Domain.ValueObjects;
using TaskManagement.Tests.Domain.Arrangements;

namespace TeskManagement.Tests.Domain.Entities.Internal;

public class TaskTests
{
    [Fact]
    public void WhenEverythingIsFine_ShouldPass()
    {
        var taskTitle = "Test Task";
        var taskDescription = "This is a test task.";
        var dueDate = DateTime.UtcNow.AddDays(7);
        var status = "Pending";
        var priority = "High";
        var projectId = Guid.NewGuid().ToString();

        var task = TaskManagement.Domain.Entities.Internal.Task.Generate(taskTitle, taskDescription, dueDate, status, priority, projectId, out var validationResults);

        Assert.NotNull(task);
        Assert.Equal(taskTitle, task.Title);
        Assert.Equal(taskDescription, task.Description);
        Assert.Equal(dueDate, task.DueDate);
        Assert.Equal(TaskManagement.Domain.Enums.TaskStatus.Pending, task.Status);
        Assert.Equal(TaskPriority.High, task.Priority);
        Assert.Equal(projectId, task.ProjectId);
        Assert.Empty(validationResults);
    }

    [Fact]
    public void WhenTaskIsRemovedFromProject_ProjectIdShouldBeNull()
    {
        var task = TaskArrangements.ValidTask;

        Assert.NotNull(task.ProjectId);

        string userId = Guid.NewGuid().ToString();
        task.RemoveFromProject(userId);

        Assert.Null(task.ProjectId);
        Assert.Equal("ProjectId", task.ChangeHistory.First().FieldName);
    }

    [Fact]
    public void WhenANewCommentIsAppend_CommentListShouldBeIncreased()
    {
        var task = TaskArrangements.ValidTask;

        Assert.Empty(task.Comments);

        var comment = new TaskComment("TestUserId", "This is a test comment.");

        task.AppendComment(comment);

        Assert.Single(task.Comments);
        Assert.Equal(comment.UserId, task.Comments.First().UserId);
    }

    [Fact]
    public void WhenStatusAreUpdated_ShouldUpdateStatusAndChangeHistory()
    {
        var task = TaskArrangements.ValidTask;

        Assert.Equal(TaskManagement.Domain.Enums.TaskStatus.Pending, task.Status);

        string userId = Guid.NewGuid().ToString();
        task.UpdateStatus(TaskManagement.Domain.Enums.TaskStatus.Finished.ToString(), userId, out var validationResults);

        Assert.Equal(TaskManagement.Domain.Enums.TaskStatus.Finished, task.Status);
        Assert.Equal("Status", task.ChangeHistory.First().FieldName);
        Assert.Equal(TaskManagement.Domain.Enums.TaskStatus.Pending.ToString(), task.ChangeHistory.First().OldValue);
        Assert.Equal(TaskManagement.Domain.Enums.TaskStatus.Finished.ToString(), task.ChangeHistory.First().NewValue);
    }
}
