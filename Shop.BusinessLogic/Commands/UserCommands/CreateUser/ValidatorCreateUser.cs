using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Commands.UserCommands.CreateUser
{
    public class ValidatorCreateUser : IValidationHandler<CommandCreateUser>
    {
        private readonly UserManager<User> _userManager;

        public ValidatorCreateUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ValidationResult> Validate(CommandCreateUser request)
        {
            var resultEmail = await _userManager.FindByEmailAsync(request.User.Email);
            if (resultEmail is not null)
                return ValidationResult.Fail("A user with such an email has already been registered");
            var resultUserName = await _userManager.FindByNameAsync(request.User.UserName);
            if (resultUserName is not null)
                return ValidationResult.Fail("A user with such an user has already been registered");
            return ValidationResult.Success;
        }
    }
}