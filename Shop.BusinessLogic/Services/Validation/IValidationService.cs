using Store.BusinessLogic.Validation;

namespace Store.BusinessLogic.Services.Validation
{
    public interface IValidationService
    {
        ValidationResult ReferencedObjectsCheckForNull(params ReferencedObjectCheck[] objects);
    }
}