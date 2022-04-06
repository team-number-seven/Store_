using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class ValidatorLoginUser : IValidationHandler<QueryLoginUser>
    {
        private readonly UserManager<User> _userManager;
        private readonly CustomerSignInManager _signInManager;

        public ValidatorLoginUser(UserManager<User> userManager, CustomerSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ValidationResult> Validate(QueryLoginUser request, CancellationToken cancellationToken)
        {
            if (request.User is null)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            if (user is null)
                return ValidationResult.Fail("Username or password is incorrect");
            if(user.EmailConfirmed is false)
                return ValidationResult.Fail("Confirm email");
            var signInResult = await _signInManager.PasswordSignInAsync(user, request.User.Password);
            return signInResult.Succeeded
                ? ValidationResult.Success
                : ValidationResult.Fail("Username or password is incorrect");
        }
    }
}