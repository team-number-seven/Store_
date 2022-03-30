using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Queries.GenderQueries.GetGenderById;
using Store.DAL;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public class HandlerGetItemById : IRequestHandler<QueryGetItemById, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetItemById> _logger;
        private readonly IMapper _mapper;

        public HandlerGetItemById(IStoreDbContext context, ILogger<HandlerGetItemById> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryGetItemById request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);
            await _context.Entry(item).Reference(i => i.CharacteristicItem).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.ItemType).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.Gender).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.AgeTypeItem).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.Color).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.SeasonItem).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.SizeTypeItem).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.SubItemType).LoadAsync(cancellationToken);
            await _context.Entry(item.CharacteristicItem).Reference(i => i.SeasonItem).LoadAsync(cancellationToken);
            await _context.Entry(item).Reference(i => i.Brand).LoadAsync(cancellationToken);
            await _context.Entry(item).Collection(i => i.Images).LoadAsync(cancellationToken);

            var result = _mapper.Map<ItemDTO>(item);
            foreach (var image in item.Images)
                result.Images.Add(await ItemDTO.CreateFileAsync(image));

            _logger.LogInformation(MHFL.Done("Handler"));
            return new ResponseGetItemById(result);
        }
    }
}