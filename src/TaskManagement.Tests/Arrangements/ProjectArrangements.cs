using TaskManagement.Domain.Entities.Internal;

namespace TaskManagement.Tests.Arrangements;

public static class ProjectArrangements
{
    public static Project ValidProject => Project.Generate("Test Title", "Test Description", "user123", out _)!;
}
