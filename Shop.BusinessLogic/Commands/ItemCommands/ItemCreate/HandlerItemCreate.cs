using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public class HandlerItemCreate : IRequestHandler<CommandCreateItem, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerItemCreate> _logger;
        private readonly IMediator _mediator;
        private readonly string _mainPath;

        public HandlerItemCreate(IStoreDbContext context, ILogger<HandlerItemCreate> logger, IMediator mediator,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _mediator = mediator;
            _mainPath = configuration["ImagesPath"];
        }

        public async Task<ResponseBase> Handle(CommandCreateItem request, CancellationToken cancellationToken)
        {
            var dto = request.Item;
            var brand = await _context.Brands.FindAsync(dto.BrandId);
            var color = await _context.Colors.FindAsync(dto.ColorId);
            var sizeTypeItem = await _context.SizeTypeItems.FindAsync(dto.SizeTypeItemId);
            var ageTypeItem = await _context.AgeTypes.FindAsync(dto.AgeTypeItemId);
            var seasonItem = await _context.SeasonItems.FindAsync(dto.SeasonItemId);
            var gender = await _context.Genders.FindAsync(dto.GenderId);
            var itemType = await _context.ItemTypes.FindAsync(dto.ItemTypeId);
            var subItemType = await _context.SubItemTypes.FindAsync(dto.SubItemTypeId);

            var characteristic = new CharacteristicItem
            {
                Color = color, SizeTypeItem = sizeTypeItem, AgeTypeItem = ageTypeItem, SeasonItem = seasonItem,
                Gender = gender, ItemType = itemType, SubItemType = subItemType,Id = Guid.NewGuid()
            };

            var images = new List<ItemImage>();

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
                images.Add(new ItemImage{Id=guid,ImageFormat = format,Path = path});
            }


            var price = 0m;
            decimal.TryParse(dto.Price,NumberStyles.Any,CultureInfo.InvariantCulture, out price);
            var newItem = new Item
            {
                Id = Guid.NewGuid(), ArticleNumber = dto.ArticleNumber, Description = dto.Description,
                NumberOfSales = 0,
                CountItem = uint.Parse(dto.CountItem), Price = price,
                CharacteristicItem = characteristic,
                Brand = brand,
                Images = images
            };
            await _context.Images.AddRangeAsync(images,cancellationToken);
            await _context.CharacteristicItems.AddAsync(characteristic,cancellationToken);
            await _context.Items.AddAsync(newItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseItemCreate(newItem.Id);
        }
    }
}