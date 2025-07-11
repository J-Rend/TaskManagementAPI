using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.Api.Request.Task;

[ExcludeFromCodeCoverage]
public class CreateTaskRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; }

    public string Priority { get; set; }

    public string? ProjectId { get; set; }
}
