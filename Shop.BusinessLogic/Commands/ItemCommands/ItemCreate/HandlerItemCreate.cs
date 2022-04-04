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
        private readonly string _imagePath;



        public HandlerItemCreate(IStoreDbContext context, ILogger<HandlerItemCreate> logger,IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _imagePath = configuration["ImagesPath"];
        }

        public async Task<ResponseBase> Handle(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var dto = request.Item;
            var price = decimal.Parse(dto.Price, NumberStyles.Any, CultureInfo.InvariantCulture);
            var countItem = uint.Parse(dto.CountItem);
            var characteristic = await CreateCharacteristicItemAsync(dto,cancellationToken);
            var images = await CreateImagesItemAsync(dto, cancellationToken);
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
                Brand = await _context.Brands.FindAsync(dto.BrandId,cancellationToken),
                Images = images
            };
            await _context.Images.AddRangeAsync(images, cancellationToken);
            await _context.CharacteristicItems.AddAsync(characteristic, cancellationToken);
            await _context.Items.AddAsync(newItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handler"));
            return new ResponseItemCreate(newItem.Id);
        }

        private async Task<IList<ItemImage>> CreateImagesItemAsync(ItemCreateDTO dto, CancellationToken cancellationToken = new())
        {
            var images = new List<ItemImage>();
            foreach (var image in dto.Files)
            {
                var format = await _context.ImageFormats
                    .FirstOrDefaultAsync(f => f.Format == image.ContentType, cancellationToken);

                var guid = Guid.NewGuid();
                var path = _imagePath + guid + image.GetImageFormat();
                using (var stream = File.Create(path))
                {
                    await image.CopyToAsync(stream, cancellationToken);
                }

                images.Add(new ItemImage { Id = guid, ImageFormat = format, Path = path});
            }

            return images;
        }

        private async Task<CharacteristicItem> CreateCharacteristicItemAsync(ItemCreateDTO dto,CancellationToken cancellationToken = new())
        {
            var color = await _context.Colors.FindAsync(dto.ColorId,cancellationToken);
            var sizeTypeItem = await _context.SizeTypeItems.FindAsync(dto.SizeTypeItemId, cancellationToken);
            var ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeItemId, cancellationToken);
            var seasonItem = await _context.SeasonItems.FindAsync(dto.SeasonItemId, cancellationToken);
            var gender = await _context.Genders.FindAsync(dto.GenderId, cancellationToken);
            var itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId, cancellationToken);
            var subItemType = await _context.SubItemTypes.FindAsync(dto.SubItemTypeId, cancellationToken);

            return new CharacteristicItem
            {
                Color = color,
                SizeTypeItem = sizeTypeItem,
                AgeTypeItem = ageTypeItem,
                SeasonItem = seasonItem,
                Gender = gender,
                ItemType = itemType,
                SubItemType = subItemType,
                Id = Guid.NewGuid()
            };
        }
    }
}