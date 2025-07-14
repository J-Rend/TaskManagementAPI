using TaskManagement.Application.UseCases.Reports.TaskReportByUser;

namespace TaskManagement.Tests.Application.UseCases.Reports.TaskReportByUser;

public class TaskReportByUserInputTest
{

    [Fact]
    public void ConstructorTest_ShouldPass()
    {
        var startDate = DateTime.Now;
        var endDate = DateTime.Now;
        var userIdentifier = "teste123";

        var input = new TaskReportByUserInput(startDate,endDate,userIdentifier);

        Assert.Equal(startDate, input.StartDate);
        Assert.Equal(endDate, input.EndDate);
        Assert.Equal(userIdentifier, input.UserIdentifier);
    }
}
