﻿using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Services.Validation;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public class ValidatorItemCreate : IValidationHandler<CommandCreateItem>
    {
        private readonly IStoreDbContext _context;

        public ValidatorItemCreate(IStoreDbContext context, IValidationService validationService)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var item = request.Item;
            if (item is null)
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(nameof(item)));

            if (string.IsNullOrEmpty(item.ArticleNumber))
                return ValidationResult.Fail(
                    LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(nameof(item.ArticleNumber)));

            if (string.IsNullOrEmpty(item.Description))
                return ValidationResult.Fail(
                    LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(nameof(item.Description)));

            if (string.IsNullOrEmpty(item.Price) || !decimal.TryParse(item.Price, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out _))
                return ValidationResult.Fail("Invalid Format Price");

            if (string.IsNullOrEmpty(item.Title))
                return ValidationResult.Fail(LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(nameof(item.Title)));

            if (await _context.AgeTypes.FindAsync(item.AgeTypeItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(item.AgeTypeItemId)));

            if (await _context.Brands.FindAsync(item.BrandId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(item.BrandId)));

            if (await _context.Colors.FindAsync(item.ColorId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(item.ColorId)));

            if (await _context.ItemTypes.FindAsync(item.ItemTypeId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(item.ItemTypeId)));

            if (await _context.SeasonItems.FindAsync(item.SeasonItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(item.SeasonItemId)));

            if (await _context.SubItemTypes.FindAsync(item.SubItemTypeId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(item.SubItemTypeId)));

            if (await _context.Items.FirstOrDefaultAsync(i => i.ArticleNumber == item.ArticleNumber,
                    cancellationToken) is not null)
                return ValidationResult.Fail("ArticleNumber is already exist");

            var resultValidateFilesAsync = await ValidateFilesAsync(item.Files);
            if (await ValidateFilesAsync(item.Files) != ValidationResult.Success)
                return resultValidateFilesAsync;

            var resultValidateSizeCountItemsCreateDtoAsync =
                await ValidateSizeCountItemsCreateDtoAsync(item.SizeCountItemsCreateDto);
            return resultValidateSizeCountItemsCreateDtoAsync != ValidationResult.Success
                ? resultValidateSizeCountItemsCreateDtoAsync
                : ValidationResult.Success;
        }

        private async Task<ValidationResult> ValidateSizeCountItemsCreateDtoAsync(
            IList<SizeCountItemCreateDto> sizesCountItemDto)
        {
            if (sizesCountItemDto is null || sizesCountItemDto.Count is 0)
                return ValidationResult.Fail(
                    LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(nameof(sizesCountItemDto)));

            var validationResult = await Task.Run(async () =>
            {
                foreach (var size in sizesCountItemDto)
                {
                    if (await _context.SizeTypeItems.FindAsync(size.SizeId) is null)
                        return ValidationResult.Fail(
                            LoggerMessages.NotFoundMessage(nameof(size)));
                }

                return ValidationResult.Success;
            });

            return validationResult;
        }

        private async Task<ValidationResult> ValidateFilesAsync(IList<IFormFile> files)
        {
            if (files is null || files.Count is 0)
                return ValidationResult.Fail(
                    LoggerMessages.ObjectPropertyIsNullOrEmptyMessage(nameof(files)));

            var validationResult = await Task.Run(async () =>
            {
                foreach (var file in files)
                {
                    if (await _context.ImageFormats.FirstOrDefaultAsync(f => f.Format == file.ContentType) is null)
                        return ValidationResult.Fail(
                            LoggerMessages.NotFoundMessage(nameof(file)));
                }

                return ValidationResult.Success;
            });

            return validationResult;
        }
    }
}