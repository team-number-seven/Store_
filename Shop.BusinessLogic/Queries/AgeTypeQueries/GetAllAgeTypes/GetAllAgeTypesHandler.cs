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

namespace Store.BusinessLogic.Queries.AgeTypeQueries.GetAllAgeTypes
{
    public class GetAllAgeTypesHandler : IRequestHandler<GetAllAgeTypesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllAgeTypesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllAgeTypesHandler(IStoreDbContext context, IMapper mapper,
            ILogger<GetAllAgeTypesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllAgeTypesQuery request, CancellationToken cancellationToken)
        {
            var ageItemTypes = await _context.AgeTypes.ToListAsync(cancellationToken);
            var ageTypesItemDto = await CreateAgeTypeItemDtoAsync(ageItemTypes, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new GetAllAgeTypesResponse(ageTypesItemDto);
        }

        private async Task<List<AgeTypeDto>> CreateAgeTypeItemDtoAsync(
            IReadOnlyCollection<AgeType> ageTypeItems,
            CancellationToken cancellationToken)
        {
            var dtos = new List<AgeTypeDto>();
            await Task.Run(() => { dtos.AddRange(ageTypeItems.Select(type => _mapper.Map<AgeTypeDto>(type))); },
                cancellationToken);
            return dtos;
        }
    }
}