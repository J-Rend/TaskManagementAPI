using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.Api.Request.Project;

[ExcludeFromCodeCoverage]
public class CreateProjectRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}
