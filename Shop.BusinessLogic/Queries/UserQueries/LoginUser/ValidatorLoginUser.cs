using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class ValidatorLoginUser : IValidationHandler<QueryLoginUser>
    {
        private readonly UserManager<User> _userManager;

        public ValidatorLoginUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ValidationResult> Validate(QueryLoginUser request)
        {
            if (request.User is null)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            if (user is null)
                return ValidationResult.Fail("Username or password is incorrect");
            var result =
                _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, request.User.Password);
            if (result is not PasswordVerificationResult.Success)
                return ValidationResult.Fail("Username or password is incorrect");
            return ValidationResult.Success;
        }
    }
}