using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Gender;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.GenderQueries.GetAllGenders
{
    public class GetAllGendersHandler : IRequestHandler<GetAllGendersQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllGendersHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllGendersHandler(IStoreDbContext context, ILogger<GetAllGendersHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            var genders = await _context.Genders.ToListAsync(cancellationToken);
            var gendersDto = await CreateGendersDtoAsync(genders, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new GetAllGendersResponse(gendersDto);
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