using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypeAndSubType
{
    public class HandlerGetAllTypeAndSubType : IRequestHandler<QueryGetAllTypeAndSubType, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllTypeAndSubType> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllTypeAndSubType(IStoreDbContext context, IMapper mapper,
            ILogger<HandlerGetAllTypeAndSubType> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllTypeAndSubType request, CancellationToken cancellationToken)
        {
            var types = await _context.ItemTypes.ToListAsync(cancellationToken);
            var itemTypesAndSubTypesDto = await CreateItemTypeAndSubTypeDtoAsync(types, cancellationToken);
            _logger.LogInformation(MHFL.Done("Handler"));
            return new ResponseGetAllTypeAndSubType(itemTypesAndSubTypesDto);
        }

        private async Task<List<ItemTypeAndSubTypeDto>> CreateItemTypeAndSubTypeDtoAsync(
            IReadOnlyCollection<ItemType> itemTypes, CancellationToken cancellationToken)
        {
            var itemTypesAndSubTypesDto = new List<ItemTypeAndSubTypeDto>();
            await Task.Run(
                () =>
                {
                    itemTypesAndSubTypesDto.AddRange(itemTypes.Select(type =>
                        _mapper.Map<ItemTypeAndSubTypeDto>(type)));
                }, cancellationToken);
            return itemTypesAndSubTypesDto;
        }
    }
}