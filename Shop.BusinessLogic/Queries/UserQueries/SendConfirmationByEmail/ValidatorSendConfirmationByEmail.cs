using System.Threading;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public class ValidatorSendConfirmationByEmail : IValidationHandler<QuerySendConfirmationByEmail>
    {
        private readonly IStoreDbContext _context;

        public ValidatorSendConfirmationByEmail(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(QuerySendConfirmationByEmail request,
            CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(request.UserId) is null
                ? ValidationResult.Fail(LoggerMessages.NotFoundMessage($"user id[{request.UserId}]"))
                : ValidationResult.Success;
        }
    }
}