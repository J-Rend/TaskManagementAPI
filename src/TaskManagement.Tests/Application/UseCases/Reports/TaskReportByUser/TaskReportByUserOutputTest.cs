using TaskManagement.Application.UseCases.Reports.TaskReportByUser;
using TaskManagement.Tests.Arrangements;

namespace TaskManagement.Tests.Application.UseCases.Reports.TaskReportByUser;

public class TaskReportByUserOutputTest
{
    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var startDate = DateTime.Now;
        var endDate = DateTime.Now;
        var userIdentifier = "teste123";
        var tasks = new List<Domain.Entities.Internal.Task>
        {
            TaskArrangements.ValidPendingTask,
            TaskArrangements.ValidFinishedTask,
            TaskArrangements.ValidInProgressTask
        };

        var output = new TaskReportByUserOutput(startDate,endDate,userIdentifier,tasks);

        Assert.Equal(startDate, output.StartDate);
        Assert.Equal(endDate, output.EndDate);
        Assert.Equal(userIdentifier, output.UserIdentifier);
        Assert.Equal(1, output.FinishedTasksQuantity);
        Assert.Equal(1, output.InProgressTasksQuantity);
        Assert.Equal(1, output.PendingTasksQuantity);
        Assert.Equal(3, output.TotalTasksQuantity);
    }
}
