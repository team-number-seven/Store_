using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public class ValidatorDeleteUser : IValidationHandler<CommandDeleteUser>
    {
        private readonly UserManager<User> _userManager;

        public ValidatorDeleteUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ValidationResult> Validate(CommandDeleteUser request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByIdAsync(request.UserId.ToString()) is null
                ? ValidationResult.Fail(MHFL.NotFount($"user id[{request.UserId}]"))
                : ValidationResult.Success;
        }
    }
}