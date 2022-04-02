﻿using System;
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

        public async Task<ValidationResult> Validate(QueryGenderById request)
        {
            if (request.Id == Guid.Empty)
                return ValidationResult.Fail(MHFL.ObjectIsNullOrEmptyMessage);
            if (await _context.Genders.FindAsync(request.Id) is null)
                return ValidationResult.Fail(MHFL.NotFount("Gender"));
            return ValidationResult.Success;
        }
    }
}