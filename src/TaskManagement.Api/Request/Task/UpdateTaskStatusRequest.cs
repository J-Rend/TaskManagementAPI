using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.Api.Request.Task;

[ExcludeFromCodeCoverage]
public class UpdateTaskStatusRequest
{
    public string Status { get; set; }
}
