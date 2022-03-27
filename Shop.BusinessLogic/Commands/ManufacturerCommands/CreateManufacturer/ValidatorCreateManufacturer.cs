using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer
{
    public class ValidatorCreateManufacturer : IValidationHandler<CommandCreateManufacturer>
    {
        private readonly IStoreDbContext _context;

        public ValidatorCreateManufacturer(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CommandCreateManufacturer request)
        {
            if (string.IsNullOrEmpty(request.Title))
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            var result = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Title == request.Title);
            if (result is not null)
                return ValidationResult.Fail(MHFL.ObjectExists(result.Title));
            return ValidationResult.Success;
        }
    }
}