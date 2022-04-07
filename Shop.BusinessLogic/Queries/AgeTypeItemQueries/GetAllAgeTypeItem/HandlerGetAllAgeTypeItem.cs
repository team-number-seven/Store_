using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.AgeType;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem
{
    public class HandlerGetAllAgeTypeItem : IRequestHandler<QueryGetAllAgeTypeItem, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllAgeTypeItem> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllAgeTypeItem(IStoreDbContext context, IMapper mapper,
            ILogger<HandlerGetAllAgeTypeItem> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllAgeTypeItem request, CancellationToken cancellationToken)
        {
            var ageItemTypes = await _context.AgeTypes.ToListAsync(cancellationToken);
            var ageTypesItemDto = await CreateAgeTypeItemDtoAsync(ageItemTypes, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new ResponseGetAllAgeTypeItem(ageTypesItemDto);
        }

        private async Task<List<AgeTypeItemDto>> CreateAgeTypeItemDtoAsync(
            IReadOnlyCollection<AgeTypeItem> ageTypeItems,
            CancellationToken cancellationToken)
        {
            var dtos = new List<AgeTypeItemDto>();
            await Task.Run(() => { dtos.AddRange(ageTypeItems.Select(type => _mapper.Map<AgeTypeItemDto>(type))); },
                cancellationToken);
            return dtos;
        }
    }
}