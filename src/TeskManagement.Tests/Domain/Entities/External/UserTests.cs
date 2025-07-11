namespace TeskManagement.Tests.Domain.Entities.External;

public class UserTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var externalIdentifier = "12345";
        var role = "Admin";

        // Act
        var user = new TaskManagement.Domain.Entities.External.User(externalIdentifier, role);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(externalIdentifier, user.ExternalIdentifier);
        Assert.Equal(role, user.Role);
    }
}
