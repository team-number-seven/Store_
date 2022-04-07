using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Validation;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class ValidatorLoginUser : IValidationHandler<QueryLoginUser>
    {
        private readonly CustomerSignInManager _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IValidationService _validationService;

        public ValidatorLoginUser(UserManager<User> userManager, CustomerSignInManager signInManager,
            IValidationService validationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _validationService = validationService;
        }

        public async Task<ValidationResult> Validate(QueryLoginUser request, CancellationToken cancellationToken)
        {
            var userDto = request.User;

            var result = _validationService.ReferencedObjectsCheckForNull(
                new ReferencedObjectsCheckForNull(userDto.Email, nameof(userDto.Email)),
                new ReferencedObjectsCheckForNull(userDto.Password, nameof(userDto.Password)),
                new ReferencedObjectsCheckForNull(userDto, nameof(userDto)));

            if (result.IsSuccessful is false) return result;
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            if (user is null) return ValidationResult.Fail("Username or password is incorrect");
            if (user.EmailConfirmed is false) return ValidationResult.Fail("Confirm email");
            var signInResult = await _signInManager.PasswordSignInAsync(user, request.User.Password);

            return signInResult.Succeeded
                ? ValidationResult.Success
                : ValidationResult.Fail("Username or password is incorrect");
        }
    }
}