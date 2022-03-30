using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Common.Extensions;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public class HandlerItemCreate : IRequestHandler<CommandCreateItem, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerItemCreate> _logger;
        private readonly string _mainPath;
        private readonly Brand _brand;
        private readonly Color _color;
        private readonly SizeTypeItem _sizeTypeItem;
        private readonly AgeTypeItem _ageTypeItem;
        private readonly SeasonItem _seasonItem;
        private readonly Gender _gender;
        private readonly ItemType _itemType;
        private readonly SubItemType _subItemType;


        public HandlerItemCreate(IStoreDbContext context, ILogger<HandlerItemCreate> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var dto = request.Item;
            await FindAndLoadReferenceEntities(dto, _brand, _color, _sizeTypeItem, _ageTypeItem, _seasonItem,
                _gender, _itemType, _subItemType);
            var price = decimal.Parse(dto.Price, NumberStyles.Any, CultureInfo.InvariantCulture);
            var countItem = uint.Parse(dto.CountItem);

            var characteristic = new CharacteristicItem
            {
                Color = _color, SizeTypeItem = _sizeTypeItem, AgeTypeItem = _ageTypeItem, SeasonItem = _seasonItem,
                Gender = _gender, ItemType = _itemType, SubItemType = _subItemType, Id = Guid.NewGuid()
            };
            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ArticleNumber = dto.ArticleNumber,
                Description = dto.Description,
                NumberOfSales = 0,
                CountItem = countItem,
                Price = price,
                CharacteristicItem = characteristic,
                Brand = _brand,
            };
            await _context.CharacteristicItems.AddAsync(characteristic, cancellationToken);
            await _context.Items.AddAsync(newItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handler"));

            return new ResponseItemCreate(newItem.Id);
        }

        private async Task FindAndLoadReferenceEntities(ItemCreateDTO dto, Brand brand, Color color,
            SizeTypeItem sizeTypeItem, AgeTypeItem ageTypeItem, SeasonItem seasonItem, Gender gender, ItemType itemType,
            SubItemType subItemType)
        {
            brand = await _context.Brands.FindAsync(dto.BrandId);
            color = await _context.Colors.FindAsync(dto.ColorId);
            sizeTypeItem = await _context.SizeTypeItems.FindAsync(dto.SizeTypeItemId);
            ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeItemId);
            seasonItem = await _context.SeasonItems.FindAsync(dto.SeasonItemId);
            gender = await _context.Genders.FindAsync(dto.GenderId);
            itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId);
            subItemType = await _context.SubItemTypes.FindAsync(dto.SubItemTypeId);
        }
    }
}
/*
 *  foreach (var image in dto.Images)
            {
                var format =
                    await _context.ImageFormats.FirstOrDefaultAsync(f => f.Format == image.GetImageFormat(),
                        cancellationToken);
                var guid = Guid.NewGuid();
                var path = _mainPath + guid + format.Format;
                using (var stream = Files.Create(path))
                {
                    await image.CopyToAsync(stream, cancellationToken);
                }

                Images.Add(new ItemImage {Id = guid, ImageFormat = format, Path = path});
            }
 */