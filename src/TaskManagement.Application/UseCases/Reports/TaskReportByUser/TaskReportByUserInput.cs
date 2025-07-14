namespace TaskManagement.Application.UseCases.Reports.TaskReportByUser;

public sealed class TaskReportByUserInput
{
    public TaskReportByUserInput(DateTime startDate, DateTime endDate, string userIdentifier)
    {
        StartDate = startDate;
        EndDate = endDate;
        UserIdentifier = userIdentifier;
    }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string UserIdentifier { get; private set; }
}
