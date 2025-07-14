namespace TaskManagement.Application.UseCases.Reports.TaskReportByUser;

public sealed class TaskReportByUserOutput
{
    public TaskReportByUserOutput(DateTime startDate, DateTime endDate, string userIdentifier, IEnumerable<Domain.Entities.Internal.Task> tasks)
    {
        StartDate = startDate;
        EndDate = endDate;
        UserIdentifier = userIdentifier;
        FinishedTasksQuantity = tasks.Count(c => c.Status.Equals(Domain.Enums.TaskStatus.Finished));
        PendingTasksQuantity = tasks.Count(c => c.Status.Equals(Domain.Enums.TaskStatus.Pending));
        InProgressTasksQuantity = tasks.Count(c => c.Status.Equals(Domain.Enums.TaskStatus.InProgress));
        TotalTasksQuantity = tasks.Count();
    }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string UserIdentifier { get; private set; }

    public int FinishedTasksQuantity { get; private set; }
    public int PendingTasksQuantity { get; private set; }
    public int InProgressTasksQuantity { get; private set; }
    public int TotalTasksQuantity { get; private set; }
}
