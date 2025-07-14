namespace TeskManagement.Tests.Domain.Entities.Internal.Base;

public class EntityBaseTests
{
    [Fact]
    public async Task WhenAnEntityBaseIsInstantiated_ShouldHaveDefaultValues()
    {
        var entity = new EntityBaseTestModel();

        Assert.NotNull(entity);
        Assert.Null(entity.UpdatedAt);
    }
    [Fact]
    public async Task WhenAnEntityBaseIsInstantiatedWithId_ShouldHaveCorrectId()
    {
        var entity = new EntityBaseTestModel();

        Assert.Null(entity.UpdatedAt);

        entity.UpdateTest();

        Assert.NotNull(entity.UpdatedAt);
    }
}
