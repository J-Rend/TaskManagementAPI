using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Internal.Base;

namespace TeskManagement.Tests.Domain.Entities.Internal.Base;

public class EntityBaseTestModel : Entity
{
    public EntityBaseTestModel() : base()
    {
        
    }

    public void UpdateTest()
    {
       Update();
    }

    protected override IEnumerable<ValidationResult> Validate()
    {
        throw new NotImplementedException();
    }
}
