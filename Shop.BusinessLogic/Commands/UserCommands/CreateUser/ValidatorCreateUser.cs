using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.CreateUser
{
    public class ValidatorCreateUser : IValidationHandler<CommandCreateUser>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStoreDbContext _context;

        public ValidatorCreateUser(UserManager<User> userManager,IStoreDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ValidationResult> Validate(CommandCreateUser request)
        {
            if (request.User is null)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            if (request.User.CountryId == Guid.Empty)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            if(await _context.Countries.FindAsync(request.User.CountryId) is null)
                return ValidationResult.Fail(MHFL.NotFount("Country"));
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