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

        public HandlerItemCreate(IStoreDbContext context, ILogger<HandlerItemCreate> logger,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _mainPath = configuration["ImagesPath"];
        }

        public async Task<ResponseBase> Handle(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var dto = request.Item;
            var images = new List<ItemImage>();
            var brand = await _context.Brands.FindAsync(dto.BrandId);
            var color = await _context.Colors.FindAsync(dto.ColorId);
            var sizeTypeItem = await _context.SizeTypeItems.FindAsync(dto.SizeTypeItemId);
            var ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeItemId);
            var seasonItem = await _context.SeasonItems.FindAsync(dto.SeasonItemId);
            var gender = await _context.Genders.FindAsync(dto.GenderId);
            var itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId);
            var subItemType = await _context.SubItemTypes.FindAsync(dto.SubItemTypeId);
            var price = decimal.Parse(dto.Price, NumberStyles.Any, CultureInfo.InvariantCulture);
            var countItem = uint.Parse(dto.CountItem);

            var characteristic = new CharacteristicItem
            {
                Color = color, SizeTypeItem = sizeTypeItem, AgeTypeItem = ageTypeItem, SeasonItem = seasonItem,
                Gender = gender, ItemType = itemType, SubItemType = subItemType, Id = Guid.NewGuid()
            };
            foreach (var image in dto.Images)
            {
                var format =
                    await _context.ImageFormats.FirstOrDefaultAsync(f => f.Format == image.GetImageFormat(),
                        cancellationToken);
                var guid = Guid.NewGuid();
                var path = _mainPath + guid + format;
                using (var stream = File.Create(path))
                {
                    await image.CopyToAsync(stream, cancellationToken);
                }

                images.Add(new ItemImage {Id = guid, ImageFormat = format, Path = path});
            }

            var newItem = new Item
            {
                Title = dto.Title,
                Id = Guid.NewGuid(),
                ArticleNumber = dto.ArticleNumber,
                Description = dto.Description,
                NumberOfSales = 0,
                CountItem = countItem,
                Price = price,
                CharacteristicItem = characteristic,
                Brand = brand,
                Images = images
            };
            await _context.Images.AddRangeAsync(images, cancellationToken);
            await _context.CharacteristicItems.AddAsync(characteristic, cancellationToken);
            await _context.Items.AddAsync(newItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handler"));

            return new ResponseItemCreate(newItem.Id);
        }
    }
}