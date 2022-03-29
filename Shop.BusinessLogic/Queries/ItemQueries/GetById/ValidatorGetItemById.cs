﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public class ValidatorGetItemById:IValidationHandler<QueryGetItemById>
    {
        private readonly IStoreDbContext _context;

        public ValidatorGetItemById(IStoreDbContext context)
        {
            _context = context;
        }
        public async Task<ValidationResult> Validate(QueryGetItemById request)
        {
            return await _context.Items.FindAsync(request.Id) is null ? ValidationResult.Fail(MHFL.NotFount("Item")) : ValidationResult.Success;
        }
    }
}
