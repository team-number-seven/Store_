﻿using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByItemsFilter
{
    public class GetItemsByFilterValidator : IValidationHandler<GetItemsByFilterQuery>
    {
        private readonly IStoreDbContext _context;

        public GetItemsByFilterValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(GetItemsByFilterQuery request, CancellationToken cancellationToken)
        {
            var query = request.Query;

            if (!query.AgeTypeId.Equals(Guid.Empty) && await _context.AgeTypes.FindAsync(query.AgeTypeId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"AgeTypeId[{query.AgeTypeId}]"));

            if (query.BrandsId.IsNullOrEmpty() is false)
                foreach (var id in query.BrandsId)
                    if (await _context.Brands.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"BrandId[{id}]"));

            if (query.ColorsId.IsNullOrEmpty() is false)
                foreach (var id in query.ColorsId)
                    if (await _context.Colors.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"ColorId[{id}]"));

            if (query.GendersId.IsNullOrEmpty() is false)
                foreach (var id in query.GendersId)
                    if (await _context.Genders.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"GenderId[{id}]"));

            if (query.ItemTypesId.IsNullOrEmpty() is false)
                foreach (var id in query.ItemTypesId)
                    if (await _context.ItemTypes.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"ItemTypeId[{id}]"));

            if (query.SeasonsId.IsNullOrEmpty() is false)
                foreach (var id in query.SeasonsId)
                    if (await _context.Seasons.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"SeasonId[{id}]"));

            if (query.SizesId.IsNullOrEmpty() is false)
                foreach (var id in query.SizesId)
                    if (await _context.Sizes.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"SizeId[{id}]"));

            if (query.SubTypesId.IsNullOrEmpty() is false)
                foreach (var id in query.SubTypesId)
                    if (await _context.SubTypes.FindAsync(id) is null)
                        return ValidationResult.Fail(LoggerMessages.NotFoundMessage($"SubTypesId[{id}]"));

            if (string.IsNullOrEmpty(query.MinPrice) is false)
                if (decimal.TryParse(query.MinPrice, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                        out var minPrice) is false)
                    return ValidationResult.Fail("Invalid MinPrice");

            if (string.IsNullOrEmpty(query.MaxPrice)) return ValidationResult.Success;

            var result = decimal.TryParse(query.MaxPrice, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out var maxPrice);

            return result is false ? ValidationResult.Fail("Invalid MaxPrice") : ValidationResult.Success;
        }
    }
}