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

namespace Store.BusinessLogic.Queries.ColorQueries.GetAllColors
{
    public class HandlerGetAllColors : IRequestHandler<QueryGetAllColors, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllColors> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllColors(IStoreDbContext context, IMapper mapper, ILogger<HandlerGetAllColors> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllColors request, CancellationToken cancellationToken)
        {
            var colors = await _context.Colors.ToListAsync(cancellationToken);
            var response = new ResponseGetAllColors(new List<ColorDTO>());
            var task = new Task(() =>
            {
                foreach (var c in colors)
                    response.Colors.Add(_mapper.Map<ColorDTO>(c));
            });

            task.Start();
            task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return response;
        }
    }
}