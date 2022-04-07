using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
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

        public async Task<ValidationResult> Validate(CommandCreateItem request, CancellationToken cancellationToken)
        {
            // TODO Foreach
            var item = request.Item;
            if (item is null) return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("Item"));
            if (item.AgeTypeItemId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("AgeTypeId"));
            if (item.BrandId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("BrandId"));
            if (item.ColorId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("ColorId"));
            if (item.GenderId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("GendersId"));
            if (item.ItemTypeId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("ItemTypeId"));
            if (item.SeasonItemId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("SeasonItemId"));
            if (item.SizeTypeItemId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("SizeTypeItemId"));
            if (item.SubItemTypeId == Guid.Empty)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("SubItemTypeId"));
            if (string.IsNullOrEmpty(item.ArticleNumber))
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("ArticleNumber"));
            if (string.IsNullOrEmpty(item.CountItem))
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("CountItem"));
            if (string.IsNullOrEmpty(item.Price) || !decimal.TryParse(item.Price, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out _))
                return ValidationResult.Fail("Invalid Format Price");
            if (string.IsNullOrEmpty(item.Title))
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("Title"));
            if (await _context.AgeTypes.FindAsync(item.AgeTypeItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("AgeTypeItemId"));
            if (await _context.Brands.FindAsync(item.BrandId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("BrandId"));
            if (await _context.Colors.FindAsync(item.ColorId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("ColorId"));
            if (await _context.ItemTypes.FindAsync(item.ItemTypeId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("ItemTypeId"));
            if (await _context.SeasonItems.FindAsync(item.SeasonItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("SeasonItemId"));
            if (await _context.SizeTypeItems.FindAsync(item.SizeTypeItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("SizeTypeItemId"));
            if (await _context.SubItemTypes.FindAsync(item.SubItemTypeId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("SubItemTypeId"));
            if (await _context.Items.FirstOrDefaultAsync(i => i.ArticleNumber == item.ArticleNumber, cancellationToken)
                is not null)
                return ValidationResult.Fail("ArticleNumber is already exist");
            if (uint.TryParse(item.CountItem, NumberStyles.Integer, CultureInfo.InvariantCulture, out _) is false)
                return ValidationResult.Fail("CountItem must be a uint type");

            return ValidationResult.Success;
        }
    }
}