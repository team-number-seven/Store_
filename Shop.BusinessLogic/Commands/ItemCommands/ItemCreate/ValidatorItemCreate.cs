﻿using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Services.Validation;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public class ValidatorItemCreate : IValidationHandler<CommandCreateItem>
    {
        private readonly IStoreDbContext _context;
        private readonly IValidationService _validationService;

        public ValidatorItemCreate(IStoreDbContext context, IValidationService validationService)
        {
            _context = context;
            _validationService = validationService;
        }

        public async Task<ValidationResult> Validate(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var item = request.Item;
            if (item is null) return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("Item"));

            if (string.IsNullOrEmpty(item.ArticleNumber))
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("ArticleNumber"));

            if (request.Item.SizeCountItemsCreateDto is null || request.Item.SizeCountItemsCreateDto.Count == 0)
            {
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage("SizeCountItemsCreateDto"));

            }


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


            if (await _context.SubItemTypes.FindAsync(item.SubItemTypeId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("SubItemTypeId"));

            return await _context.Items.FirstOrDefaultAsync(i => i.ArticleNumber == item.ArticleNumber,
                    cancellationToken)
                is not null
                ? ValidationResult.Fail("ArticleNumber is already exist")
                : ValidationResult.Success;
            //TODO CHECK IMAGES
        }
    }
}