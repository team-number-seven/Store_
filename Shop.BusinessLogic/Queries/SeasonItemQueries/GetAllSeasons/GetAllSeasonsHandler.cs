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

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasons
{
    public class GetAllSeasonsHandler : IRequestHandler<GetAllSeasonsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllSeasonsHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllSeasonsHandler(IStoreDbContext context, IMapper mapper, ILogger<GetAllSeasonsHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllSeasonsQuery request, CancellationToken cancellationToken)
        {
            var seasonsItem = await _context.Seasons.ToListAsync(cancellationToken);
            var seasonsItemDto = await CreateSeasonDtoAsync(seasonsItem, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new GetAllSeasonsResponse(seasonsItemDto);
        }

        public async Task<IList<SeasonDto>> CreateSeasonDtoAsync(IReadOnlyCollection<Season> seasonsItem,
            CancellationToken cancellationToken)
        {
            var seasonsItemDto = new List<SeasonDto>();
            await Task.Run(
                () => { seasonsItemDto.AddRange(seasonsItem.Select(season => _mapper.Map<SeasonDto>(season)).OrderBy(x=>x.Title)); },
                cancellationToken);

            return seasonsItemDto;
        }
    }
}