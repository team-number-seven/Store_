using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
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
            var response = new ResponseGetAllSeasonItem(new List<SeasonItemDTO>());
            var task = new Task(() =>
            {
                foreach (var season in seasonsItem)
                    response.Seasons.Add(_mapper.Map<SeasonItemDTO>(season));
            });
            task.Start();
            task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return response;
        }
    }
}