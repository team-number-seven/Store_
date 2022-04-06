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

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public class ValidatorSendConfirmationByEmail:IValidationHandler<QuerySendConfirmationByEmail>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStoreDbContext _context;

        public ValidatorSendConfirmationByEmail(UserManager<User> userManager,IStoreDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ValidationResult> Validate(QuerySendConfirmationByEmail request, CancellationToken cancellationToken)
        {
            if (await _context.Users.FindAsync(request.UserId) is null)
                return ValidationResult.Fail(MHFL.NotFount($"user id[{request.UserId}]"));
            return ValidationResult.Success;
        }
    }
}
