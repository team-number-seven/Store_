using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;

namespace Store.BusinessLogic.Services.Validation
{
    public class ValidationService : IValidationService
    {
        public ValidationResult ReferencedObjectsCheckForNull(params ReferencedObjectCheckForNull[] objects)
        {
            foreach (var (value, typeObject) in objects)
                if (value is null)
                    return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(typeObject));
            return ValidationResult.Success;
        }
    }
}