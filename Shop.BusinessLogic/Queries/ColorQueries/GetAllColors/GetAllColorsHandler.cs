using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Color;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorsHandler : IRequestHandler<GetAllColorsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllColorsHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllColorsHandler(IStoreDbContext context, IMapper mapper, ILogger<GetAllColorsHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _context.Colors.ToListAsync(cancellationToken);
            var colorsDto = await CreateColorsDtoAsync(colors, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new GetAllColorsResponse(colorsDto);
        }

        private async Task<List<ColorDto>> CreateColorsDtoAsync(IReadOnlyCollection<Color> colors,
            CancellationToken cancellationToken)
        {
            var colorsDto = new List<ColorDto>();
            await Task.Run(() => { colorsDto.AddRange(colors.Select(c => _mapper.Map<ColorDto>(c)).OrderBy(x=>x.Title)); },
                cancellationToken);

            return colorsDto;
        }
    }
}