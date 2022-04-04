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

namespace Store.BusinessLogic.Queries.GenderQueries.GetAllGenders
{
    public class HandlerAllGenders : IRequestHandler<QueryAllGenders, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerAllGenders> _logger;
        private readonly IMapper _mapper;

        public HandlerAllGenders(IStoreDbContext context, ILogger<HandlerAllGenders> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryAllGenders request, CancellationToken cancellationToken)
        {
            var genders = await _context.Genders.ToListAsync(cancellationToken);
            var gendersDto = await CreateGendersDtoAsync(genders, cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return new ResponseGetAllGenders(gendersDto);
        }

        private async Task<List<GenderDto>> CreateGendersDtoAsync(IReadOnlyCollection<Gender> genders,
            CancellationToken cancellationToken)
        {
            var gendersDto = new List<GenderDto>();
            await Task.Run(() => { gendersDto.AddRange(genders.Select(c => _mapper.Map<GenderDto>(c))); },
                cancellationToken);
            return gendersDto;
        }
    }
}