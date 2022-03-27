using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public class ValidationGenderById:IValidationHandler<QueryGenderById>
    {
        private readonly IStoreDbContext _context;

        public ValidationGenderById(IStoreDbContext context)
        {
            _context = context;
        }
        public async Task<ValidationResult> Validate(QueryGenderById request)
        {
            if (Guid.Parse(request.Id) == Guid.Empty)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            var result = await _context.Genders.FindAsync(request.Id);
            if(result is null)
                return ValidationResult.Fail("Gender not found");
            return ValidationResult.Success;
        }
    }
}
