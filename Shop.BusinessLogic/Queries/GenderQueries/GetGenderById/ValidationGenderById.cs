using System;
using System.Threading;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public class ValidationGenderById : IValidationHandler<QueryGenderById>
    {
        private readonly IStoreDbContext _context;

        public ValidationGenderById(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(QueryGenderById request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty) return ValidationResult.Fail(LoggerMessages.ObjectIsNullOrEmptyMessage);

            return await _context.Genders.FindAsync(request.Id) is null
                ? ValidationResult.Fail(LoggerMessages.NotFoundMessage("Gender"))
                : ValidationResult.Success;
        }
    }
}