using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Commands.UserCommands.create
{
    public static partial class CreateUser
    {
        public class Validator : IValidationHandler<Command>
        {
            private readonly UserManager<User> _userManager;

            public Validator(UserManager<User> userManager)
            {
                _userManager = userManager;
            }
            public async Task<ValidationResult> Validate(Command request)
            {
                var resultEmail = await _userManager.FindByEmailAsync(request.Email);
                if (resultEmail is not null)
                    return ValidationResult.Fail("A user with such an email has already been registered");
                var resultUserName = await _userManager.FindByNameAsync(request.UserName);
                if (resultUserName is not null)
                    return ValidationResult.Fail("A user with such an user has already been registered");
                return ValidationResult.Success;
            }
        }
    }
}
