using System;
using System.Threading;
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
        private readonly IStoreDbContext _context;
        private readonly UserManager<User> _userManager;

        public ValidatorCreateUser(UserManager<User> userManager, IStoreDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ValidationResult> Validate(CommandCreateUser request, CancellationToken cancellationToken)
        {
            if (request.User is null) return ValidationResult.Fail(LoggerMessages.ObjectIsNullOrEmptyMessage);

            if (request.User.CountryId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectIsNullOrEmptyMessage);

            if (await _context.Countries.FindAsync(request.User.CountryId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("Country"));

            var resultEmail = await _userManager.FindByEmailAsync(request.User.Email);
            if (resultEmail is not null)
                return ValidationResult.Fail("A user with such an email has already been registered");

            var resultUserName = await _userManager.FindByNameAsync(request.User.UserName);
            return resultUserName is not null
                ? ValidationResult.Fail("A user with such an user has already been registered")
                : ValidationResult.Success;
        }
    }
}