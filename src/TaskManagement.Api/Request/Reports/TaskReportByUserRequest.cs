using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.Api.Request.Reports;

[ExcludeFromCodeCoverage]
public sealed class TaskReportByUserRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserIdentifier { get; set; }
}
