using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Country;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllCountriesHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(IStoreDbContext context, ILogger<GetAllCountriesHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _context.Countries.ToListAsync(cancellationToken);
            var countriesDto = await CreateCountriesDtoAsync(countries, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new GetAllCountriesResponse(countriesDto);
        }

        private async Task<List<CountryDto>> CreateCountriesDtoAsync(IReadOnlyCollection<Country> countries,
            CancellationToken cancellationToken)
        {
            var countriesDto = new List<CountryDto>();
            await Task.Run(() => { countriesDto.AddRange(countries.Select(c => _mapper.Map<CountryDto>(c)).OrderBy(x=>x.Name)); },
                cancellationToken);

            return countriesDto;
        }
    }
}