using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Country;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public class HandlerGetCountryById : IRequestHandler<QueryGetCountryById, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetCountryById> _logger;
        private readonly IMapper _mapper;

        public HandlerGetCountryById(IStoreDbContext context, IMapper mapper, ILogger<HandlerGetCountryById> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetCountryById request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FindAsync(request.Id);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new ResponseGetCountryById(_mapper.Map<CountryDto>(country));
        }
    }
}