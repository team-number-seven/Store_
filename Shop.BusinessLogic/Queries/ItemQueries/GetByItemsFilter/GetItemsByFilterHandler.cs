using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;
using Store.BusinessLogic.Common.Extensions;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByItemsFilter
{
    public class GetItemsByFilterHandler : IRequestHandler<GetItemsByFilterQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetItemsByFilterHandler> _logger;
        private readonly IMapper _mapper;

        public GetItemsByFilterHandler(IStoreDbContext context, ILogger<GetItemsByFilterHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetItemsByFilterQuery request, CancellationToken cancellationToken)
        {
            var filteredItems = await FilterItemsAsync(_context.Items.AsQueryable(), request.Query, cancellationToken);
            var itemsDto = await CreateItemsDtoAsync(filteredItems, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new GetItemsByFilterResponse(itemsDto);
        }

        private async Task<IList<ItemQueryResponseDto>> CreateItemsDtoAsync(IList<Item> items,
            CancellationToken cancellationToken)
        {
            var itemsDto = new List<ItemQueryResponseDto>();
            await Task.Run(async () =>
            {
                foreach (var item in items)
                {
                    var dto = _mapper.Map<ItemQueryResponseDto>(item);
                    var mainImage = item.Images.First();
                    dto.Image = new FileContentResult(await File.ReadAllBytesAsync(mainImage.Path, cancellationToken),
                        mainImage.ImageFormat.Format);
                    itemsDto.Add(dto);
                }
            }, cancellationToken);
            return itemsDto;
        }

        private async Task<IList<Item>> FilterItemsAsync(IQueryable<Item> items, ItemFilterQueryDto query,
            CancellationToken cancellationToken)
        {
            if (query.GetCountItems <= 0)
                return new List<Item>();
            await Task.Run(() =>
            {
                var maxPriceTryParse = decimal.TryParse(query.MaxPrice, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out var maxPrice);
                var minPriceTryParse = decimal.TryParse(query.MinPrice, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out var minPrice);
                items = items.FilterByAge(query.AgeTypeId);
                if (maxPriceTryParse)
                    items = items.FilterByMaxPrice(maxPrice);
                if (minPriceTryParse)
                    items = items.FilterByMinPrice(minPrice);
                items = items.FilterByGender(query.GendersId);
                items = items.FilterByBrands(query.BrandsId);
                items = items.FilterBySeason(query.SeasonsId);
                items = items.FilterByItemType(query.ItemTypesId);
                items = items.FilterBySubTypes(query.SubTypesId);
                items = items.FilterBySize(query.SizesId);
                items = items.FilterByColors(query.ColorsId);
                items = items.Take(query.GetCountItems);
            }, cancellationToken);
            return await items.ToListAsync(cancellationToken);
        }
    }
}