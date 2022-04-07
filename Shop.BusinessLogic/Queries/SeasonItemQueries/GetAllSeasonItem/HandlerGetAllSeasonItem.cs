using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Season;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasonItem
{
    public class HandlerGetAllSeasonItem : IRequestHandler<QueryGetAllSeasonItem, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllSeasonItem> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllSeasonItem(IStoreDbContext context, IMapper mapper, ILogger<HandlerGetAllSeasonItem> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllSeasonItem request, CancellationToken cancellationToken)
        {
            var seasonsItem = await _context.SeasonItems.ToListAsync(cancellationToken);
            var seasonsItemDto = await CreateSeasonItemDtoAsync(seasonsItem, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new ResponseGetAllSeasonItem(seasonsItemDto);
        }

        public async Task<List<SeasonItemDto>> CreateSeasonItemDtoAsync(IReadOnlyCollection<SeasonItem> seasonsItem,
            CancellationToken cancellationToken)
        {
            var seasonsItemDto = new List<SeasonItemDto>();
            await Task.Run(
                () => { seasonsItemDto.AddRange(seasonsItem.Select(season => _mapper.Map<SeasonItemDto>(season))); },
                cancellationToken);

            return seasonsItemDto;
        }
    }
}