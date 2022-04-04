using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Common.Extensions;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByFilter
{
    public class HandlerItemFilter : IRequestHandler<QueryItemFilter, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerItemFilter> _logger;
        private readonly IMapper _mapper;

        public HandlerItemFilter(IStoreDbContext context, ILogger<HandlerItemFilter> logger,IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryItemFilter request, CancellationToken cancellationToken)
        {
            var query = request.Query;
            var priceIsTryParse = decimal.TryParse(query.Price, NumberStyles.Any, CultureInfo.InvariantCulture,out var price);
            IQueryable<Item> items = _context.Items;

            items = items.FilterByAge(query.AgeTypeId);
            if (priceIsTryParse)
                items = items.FilterByPrice(price);
            items = items.FilterByGender(query.GendersId);
            items = items.FilterByBrands(query.BrandsId);
            items = items.FilterBySeason(query.SeasonsId);
            items = items.FilterByItemType(query.ItemTypesId);
            items = items.FilterBySubTypes(query.SubItemTypesId);
            items = items.FilterBySize(query.SizesId);
            items = items.FilterByColors(query.ColorsId);

            var responseDtos = new List<ItemQueryResponseDTO>();
            var filteredItems = await items.ToListAsync(cancellationToken);
            var task = new Task(() =>
            {
                foreach (var item in filteredItems)
                {
                    var dto = _mapper.Map<ItemQueryResponseDTO>(item);
                    var maiImage = item.Images.First();
                    dto.Image = new FileContentResult(File.ReadAllBytes(maiImage.Path), maiImage.ImageFormat.Format);
                    responseDtos.Add(new ItemQueryResponseDTO{});
                }
            });
            task.Start();
            task.Wait(cancellationToken);



            throw new NotImplementedException();
        }
    }
}