using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.ItemTypeAndSubType;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypesAndSubTypes
{
    public class GetAllTypesAndSubTypesHandler : IRequestHandler<GetAllTypesAndSubTypesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllTypesAndSubTypesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllTypesAndSubTypesHandler(IStoreDbContext context, IMapper mapper,
            ILogger<GetAllTypesAndSubTypesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllTypesAndSubTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _context.ItemTypes.ToListAsync(cancellationToken);
            var itemTypesAndSubTypesDto = await CreateItemTypeAndSubTypeDtoAsync(types, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new GetAllTypesAndSubTypesResponse(itemTypesAndSubTypesDto);
        }

        private async Task<List<ItemTypeAndSubTypeDto>> CreateItemTypeAndSubTypeDtoAsync(
            IReadOnlyCollection<ItemType> itemTypes, CancellationToken cancellationToken)
        {
            var typesAndSubTypes = new List<ItemTypeAndSubTypeDto>();
            await Task.Run(() =>
            {
                typesAndSubTypes = itemTypes.Select(type => _mapper.Map<ItemTypeAndSubTypeDto>(type)).ToList();
                typesAndSubTypes.ForEach(x => x.SubItemTypes = x.SubItemTypes.OrderBy(dto => dto.Title).ToList());
            }, cancellationToken);

            return typesAndSubTypes;
        }
    }
}