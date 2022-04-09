using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Size;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.SizeQueries.GetAllSizes
{
    public class GetAllSizesHandler : IRequestHandler<GetAllSizesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllSizesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllSizesHandler(IStoreDbContext context, IMapper mapper,
            ILogger<GetAllSizesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllSizesQuery request, CancellationToken cancellationToken)
        {
            var sizes = await _context.Sizes.ToListAsync(cancellationToken);
            var sizesTypeItemDto = await CreateSizesDtoAsync(sizes, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new GetAllSizesResponse(sizesTypeItemDto);
        }

        private async Task<IEnumerable<IGrouping<string,SizeDto>>> CreateSizesDtoAsync(
            IReadOnlyCollection<Size> sizesItems, CancellationToken cancellationToken)
        {
            var sizesTypeItemDto = new List<SizeDto>();
            IEnumerable<IGrouping<string, SizeDto>> sortedSizes = null;
            await Task.Run(
                () =>
                {
                    sizesTypeItemDto.AddRange(sizesItems.Select(size => _mapper.Map<SizeDto>(size)));
                    sortedSizes = sizesTypeItemDto.GroupBy(x=>x.ItemType).ToList();
                },
                cancellationToken);
            return sortedSizes;
        }
    }
}