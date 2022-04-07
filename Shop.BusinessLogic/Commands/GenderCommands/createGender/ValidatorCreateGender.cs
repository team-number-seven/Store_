using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.GenderCommands.CreateGender
{
    public class ValidatorCreateGender : IValidationHandler<CommandCreateGender>
    {
        private readonly IStoreDbContext _context;

        public ValidatorCreateGender(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CommandCreateGender request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Title))
                return ValidationResult.Fail(LoggerMessages.ObjectIsNullOrEmptyMessage);

            var result = await _context.Genders.FirstOrDefaultAsync(g => g.Title == request.Title, cancellationToken);

            return result is not null
                ? ValidationResult.Fail("This gender already exists")
                : ValidationResult.Success;
        }
    }
}