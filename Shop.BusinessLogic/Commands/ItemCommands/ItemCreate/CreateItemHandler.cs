using System;
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
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly string _imagePath;
        private readonly ILogger<CreateItemHandler> _logger;


        public CreateItemHandler(IStoreDbContext context, ILogger<CreateItemHandler> logger,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _imagePath = configuration["CurrentDirectory"] + configuration["ImagesPath"];
        }

        public async Task<ResponseBase> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateItem;
            var price = decimal.Parse(dto.Price, NumberStyles.Any, CultureInfo.InvariantCulture);
            var images = await CreateImagesAsync(dto, cancellationToken);
            var itemCountSize = await CreateNumberOfSizeAsync(dto.CreateNumberOfSizesDto);
            var characteristic = await CreateCharacteristicAsync(dto, itemCountSize);

            var countItem = itemCountSize.Aggregate<NumberOfSize, uint>(0, (current, x) => current + x.Count);

            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ArticleNumber = dto.ArticleNumber,
                Description = dto.Description,
                NumberOfSales = 0,
                CountItem = countItem,
                Price = price,
                Characteristic = characteristic,
                Brand = await _context.Brands.FindAsync(dto.BrandId),
                Images = images
            };
            await _context.Images.AddRangeAsync(images, cancellationToken);
            await _context.Characteristics.AddAsync(characteristic, cancellationToken);
            await _context.Items.AddAsync(newItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new CreateItemResponse(newItem.Id);
        }

        private async Task<IList<Image>> CreateImagesAsync(CreateItemDto dto,
            CancellationToken cancellationToken = new())
        {
            var images = new List<Image>();
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

                images.Add(new Image {Id = guid, ImageFormat = format, Path = path});
            }

            return images;
        }

        private async Task<Characteristic> CreateCharacteristicAsync(CreateItemDto dto,
            IEnumerable<NumberOfSize> itemCountSize)
        {
            var color = await _context.Colors.FindAsync(dto.ColorId);
            var ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeId);
            var seasonItem = await _context.Seasons.FindAsync(dto.SeasonId);
            var gender = await _context.Genders.FindAsync(dto.GenderId);
            var itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId);
            var subItemType = await _context.SubTypes.FindAsync(dto.SubTypeId);

            return new Characteristic
            {
                Color = color,
                ItemCountSizes = itemCountSize,
                AgeType = ageTypeItem,
                Season = seasonItem,
                Gender = gender,
                ItemType = itemType,
                SubType = subItemType,
                Id = Guid.NewGuid()
            };
        }

        private async Task<IList<NumberOfSize>> CreateNumberOfSizeAsync(
            IEnumerable<CreateNumberOfSizeDto> sizesDto)
        {
            var itemCountSizes = new List<NumberOfSize>();
            await Task.Run(async () =>
            {
                foreach (var dto in sizesDto)
                {
                    var itemSize = await _context.Sizes.FindAsync(dto.SizeId);
                    itemCountSizes.Add(new NumberOfSize
                    {
                        Id = Guid.NewGuid(), Size = itemSize, Count = dto.Count
                    });
                }
            });

            return itemCountSizes;
        }
    }
}