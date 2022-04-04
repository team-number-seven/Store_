using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByFilter
{
    public class ValidatorItemFilter : IValidationHandler<QueryItemFilter>
    {
        private readonly IStoreDbContext _context;

        public ValidatorItemFilter(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(QueryItemFilter request)
        {
            var query = request.Query;

            if (!query.AgeTypeId.Equals(Guid.Empty) && await _context.AgeTypes.FindAsync(query.AgeTypeId) is null)
                return ValidationResult.Fail(MHFL.NotFount($"AgeTypeId[{query.AgeTypeId}]"));

            if (query.BrandsId.IsNullOrEmpty() is false)
                foreach (var id in query.BrandsId)
                    if (await _context.Brands.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"BrandId[{id}]"));

            if (query.ColorsId.IsNullOrEmpty() is false)
                foreach (var id in query.ColorsId)
                    if (await _context.Colors.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"ColorId[{id}]"));

            if (query.GendersId.IsNullOrEmpty() is false)
                foreach (var id in query.GendersId)
                    if (await _context.Genders.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"GenderId[{id}]"));

            if (query.ItemTypesId.IsNullOrEmpty() is false)
                foreach (var id in query.ItemTypesId)
                    if (await _context.ItemTypes.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"ItemTypeId[{id}]"));

            if (query.SeasonsId.IsNullOrEmpty() is false)
                foreach (var id in query.SeasonsId)
                    if (await _context.SeasonItems.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"SeasonId[{id}]"));

            if (query.SizesId.IsNullOrEmpty() is false)
                foreach (var id in query.SizesId)
                    if (await _context.SizeTypeItems.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"SizeId[{id}]"));

            if (query.SubItemTypesId.IsNullOrEmpty() is false)
                foreach (var id in query.SubItemTypesId)
                    if (await _context.SubItemTypes.FindAsync(id) is null)
                        return ValidationResult.Fail(MHFL.NotFount($"SubItemTypesId[{id}]"));

            if (string.IsNullOrEmpty(query.Price)) return ValidationResult.Success;
            var result = decimal.TryParse(query.Price, NumberStyles.Any, CultureInfo.InvariantCulture, out var price);

            return result is false ? ValidationResult.Fail("Invalid Price") : ValidationResult.Success;
        }
    }
}