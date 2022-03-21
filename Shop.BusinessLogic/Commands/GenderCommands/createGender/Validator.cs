using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.GenderCommands.createGender
{
    public static partial class CreateGender
    {
        public class Validator : IValidationHandler<Command>
        {
            private readonly IStoreDbContext _context;

            public Validator(IStoreDbContext context)
            {
                _context = context;
            }
            public async Task<ValidationResult> Validate(Command request)
            {
                var result = await _context.Genders.FirstOrDefaultAsync(g=>g.Title == request.Title);
                if(result is not null)
                    return ValidationResult.Fail("This gender already exists");
                return ValidationResult.Success;

            }
        }
    }
}
