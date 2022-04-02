using System;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public class ValidatorGetCountryById : IValidationHandler<QueryGetCountryById>
    {
        private readonly IStoreDbContext _context;

        public ValidatorGetCountryById(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(QueryGetCountryById request)
        {
            if (Guid.Empty == request.Id)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            if (await _context.Countries.FindAsync(request.Id) is null)
                return ValidationResult.Fail(MHFL.NotFount("Country"));
            return ValidationResult.Success;
        }
    }
}