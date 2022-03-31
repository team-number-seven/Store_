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
        private Brand _brand;
        private Color _color;
        private SizeTypeItem _sizeTypeItem;
        private AgeTypeItem _ageTypeItem;
        private SeasonItem _seasonItem;
        private Gender _gender;
        private ItemType _itemType;
        private SubItemType _subItemType;


        public HandlerItemCreate(IStoreDbContext context, ILogger<HandlerItemCreate> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var dto = request.Item;
            var newItem = new Item();
            await FindAndLoadReferenceEntities(dto, _brand, _color, _sizeTypeItem, _ageTypeItem, _seasonItem,
                _gender, _itemType, _subItemType);
            var price = decimal.Parse(dto.Price, NumberStyles.Any, CultureInfo.InvariantCulture);
            var countItem = uint.Parse(dto.CountItem);

            var characteristic = new CharacteristicItem
            {
                Color = _color, SizeTypeItem = _sizeTypeItem, AgeTypeItem = _ageTypeItem, SeasonItem = _seasonItem,
                Gender = _gender, ItemType = _itemType, SubItemType = _subItemType, Id = Guid.NewGuid(),Item = newItem
            };
            newItem = new Item
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
            _brand = await _context.Brands.FindAsync(dto.BrandId);
            _color = await _context.Colors.FindAsync(dto.ColorId);
            _sizeTypeItem = await _context.SizeTypeItems.FindAsync(dto.SizeTypeItemId);
            _ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeItemId);
            _seasonItem = await _context.SeasonItems.FindAsync(dto.SeasonItemId);
            _gender = await _context.Genders.FindAsync(dto.GenderId);
            _itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId);
            _subItemType = await _context.SubItemTypes.FindAsync(dto.SubItemTypeId);
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