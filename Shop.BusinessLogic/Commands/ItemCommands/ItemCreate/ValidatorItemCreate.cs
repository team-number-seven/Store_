using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public class ValidatorItemCreate : IValidationHandler<CommandCreateItem>
    {
        private readonly IStoreDbContext _context;

        public ValidatorItemCreate(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CommandCreateItem request)
        {
            var item = request.Item;
            uint temp = 0;
            var tempDecimal = 0m;
            if (item is null) return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("Item"));
            if (item.AgeTypeItemId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("AgeTypeId"));
            if (item.BrandId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("BrandId"));
            if (item.ColorId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("ColorId"));
            if (item.GenderId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("GendersId"));
            if (item.ItemTypeId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("ItemTypeId"));
            if (item.SeasonItemId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("SeasonItemId"));
            if (item.SizeTypeItemId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("SizeTypeItemId"));
            if (item.SubItemTypeId == Guid.Empty)
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("SubItemTypeId"));
            if (string.IsNullOrEmpty(item.ArticleNumber))
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("ArticleNumber"));
            if (string.IsNullOrEmpty(item.CountItem))
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("CountItem"));
            if (string.IsNullOrEmpty(item.Price) || decimal.TryParse(item.Price, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out tempDecimal))
                return ValidationResult.Fail("Invalid Format Price");
            if (string.IsNullOrEmpty(item.Title))
                return ValidationResult.Fail(MHFL.NameObjectIsNullOrEmptyMessage("Title"));
            if (await _context.AgeTypes.FindAsync(item.AgeTypeItemId) is null)
                return ValidationResult.Fail(MHFL.NotFount("AgeTypeItemId"));
            if (await _context.Brands.FindAsync(item.BrandId) is null)
                return ValidationResult.Fail(MHFL.NotFount("BrandId"));
            if (await _context.Colors.FindAsync(item.ColorId) is null)
                return ValidationResult.Fail(MHFL.NotFount("ColorId"));
            if (await _context.ItemTypes.FindAsync(item.ItemTypeId) is null)
                return ValidationResult.Fail(MHFL.NotFount("ItemTypeId"));
            if (await _context.SeasonItems.FindAsync(item.SeasonItemId) is null)
                return ValidationResult.Fail(MHFL.NotFount("SeasonItemId"));
            if (await _context.SizeTypeItems.FindAsync(item.SizeTypeItemId) is null)
                return ValidationResult.Fail(MHFL.NotFount("SizeTypeItemId"));
            if (await _context.SubItemTypes.FindAsync(item.SubItemTypeId) is null)
                return ValidationResult.Fail(MHFL.NotFount("SubItemTypeId"));
            if (await _context.Items.FirstOrDefaultAsync(i => i.ArticleNumber == item.ArticleNumber) is not null)
                return ValidationResult.Fail("ArticleNumber is already exist");
            if (uint.TryParse(item.CountItem, NumberStyles.Integer, CultureInfo.InvariantCulture, out temp) is false)
                return ValidationResult.Fail("CountItem must be a uint type");

            return ValidationResult.Success;
        }
    }
}