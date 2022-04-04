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
            var colorsDto = await CreateColorsDtoAsync(colors, cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return new ResponseGetAllColors(colorsDto);
        }

        private async Task<List<ColorDto>> CreateColorsDtoAsync(IReadOnlyCollection<Color> colors,
            CancellationToken cancellationToken)
        {
            var colorsDto = new List<ColorDto>();
            await Task.Run(() => { colorsDto.AddRange(colors.Select(c => _mapper.Map<ColorDto>(c))); },
                cancellationToken);
            return colorsDto;
        }
    }
}