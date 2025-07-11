using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.Api.Request.Task;

[ExcludeFromCodeCoverage]
public class UpdateTaskCommentsRequest
{
    public string Comment { get; set; }
}
