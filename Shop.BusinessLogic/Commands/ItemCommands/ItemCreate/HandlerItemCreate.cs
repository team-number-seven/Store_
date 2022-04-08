﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Common.DataTransferObjects.Item;
using Store.BusinessLogic.Common.Extensions;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public class HandlerItemCreate : IRequestHandler<CommandCreateItem, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly string _imagePath;
        private readonly ILogger<HandlerItemCreate> _logger;


        public HandlerItemCreate(IStoreDbContext context, ILogger<HandlerItemCreate> logger,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _imagePath = configuration["ImagesPath"];
        }

        public async Task<ResponseBase> Handle(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var dto = request.Item;
            var price = decimal.Parse(dto.Price, NumberStyles.Any, CultureInfo.InvariantCulture);
            var images = await CreateImagesItemAsync(dto, cancellationToken);
            var itemCountSize = await CreateItemCountSizeAsync(dto.SizeCountItemsCreateDto);
            var characteristic = await CreateCharacteristicItemAsync(dto, itemCountSize);

            var countItem = itemCountSize.Aggregate<ItemCountSize, uint>(0, (current, x) => current + x.Count);

            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ArticleNumber = dto.ArticleNumber,
                Description = dto.Description,
                NumberOfSales = 0,
                CountItem = uint.Parse(countItem.ToString()),
                Price = price,
                CharacteristicItem = characteristic,
                Brand = await _context.Brands.FindAsync(dto.BrandId),
                Images = images
            };
            await _context.Images.AddRangeAsync(images, cancellationToken);
            await _context.CharacteristicItems.AddAsync(characteristic, cancellationToken);
            await _context.Items.AddAsync(newItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new ResponseItemCreate(newItem.Id);
        }

        private async Task<IList<ItemImage>> CreateImagesItemAsync(ItemCreateDto dto,
            CancellationToken cancellationToken = new())
        {
            var images = new List<ItemImage>();
            foreach (var image in dto.Files)
            {
                var format = await _context.ImageFormats
                    .FirstOrDefaultAsync(f => f.Format == image.ContentType, cancellationToken);

                var guid = Guid.NewGuid();
                var path = _imagePath + guid + image.GetImageFormat();
                await using (var stream = File.Create(path))
                {
                    await image.CopyToAsync(stream, cancellationToken);
                }

                images.Add(new ItemImage {Id = guid, ImageFormat = format, Path = path});
            }

            return images;
        }

        private async Task<CharacteristicItem> CreateCharacteristicItemAsync(ItemCreateDto dto,
            IEnumerable<ItemCountSize> itemCountSize)
        {
            var color = await _context.Colors.FindAsync(dto.ColorId);
            var ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeItemId);
            var seasonItem = await _context.SeasonItems.FindAsync(dto.SeasonItemId);
            var gender = await _context.Genders.FindAsync(dto.GenderId);
            var itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId);
            var subItemType = await _context.SubItemTypes.FindAsync(dto.SubItemTypeId);

            return new CharacteristicItem
            {
                Color = color,
                ItemCountSizes = itemCountSize,
                AgeTypeItem = ageTypeItem,
                SeasonItem = seasonItem,
                Gender = gender,
                ItemType = itemType,
                SubItemType = subItemType,
                Id = Guid.NewGuid()
            };
        }

        private async Task<IList<ItemCountSize>> CreateItemCountSizeAsync(
            IEnumerable<SizeCountItemCreateDto> sizesDto)
        {
            var itemCountSizes = new List<ItemCountSize>();
            await Task.Run(async () =>
            {
                foreach (var dto in sizesDto)
                {
                    var itemSize = await _context.SizeTypeItems.FindAsync(dto.SizeId);
                    itemCountSizes.Add(new ItemCountSize
                    {
                        Id = Guid.NewGuid(), SizeTypeItem = itemSize, Count = dto.Count
                    });
                }
            });

            return itemCountSizes;
        }
    }
}