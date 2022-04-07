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

namespace Store.BusinessLogic.Queries.SizeTypeItemQueries.GetAllSizeTypeItems
{
    public class HandlerGetAllSizesTypeItems : IRequestHandler<QueryGetAllSizesTypeItems, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllSizesTypeItems> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllSizesTypeItems(IStoreDbContext context, IMapper mapper,
            ILogger<HandlerGetAllSizesTypeItems> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllSizesTypeItems request, CancellationToken cancellationToken)
        {
            var sizes = await _context.SizeTypeItems.ToListAsync(cancellationToken);
            var sizesTypeItemDto = await CreateSizesTypeItemDtoAsync(sizes, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage("Handle"));

            return new ResponseGetAllSizesTypeItems(sizesTypeItemDto);
        }

        private async Task<List<SizeTypeItemDto>> CreateSizesTypeItemDtoAsync(
            IReadOnlyCollection<SizeTypeItem> sizesItems, CancellationToken cancellationToken)
        {
            var sizesTypeItemDto = new List<SizeTypeItemDto>();
            await Task.Run(
                () => { sizesTypeItemDto.AddRange(sizesItems.Select(size => _mapper.Map<SizeTypeItemDto>(size))); },
                cancellationToken);

            return sizesTypeItemDto;
        }
    }
}