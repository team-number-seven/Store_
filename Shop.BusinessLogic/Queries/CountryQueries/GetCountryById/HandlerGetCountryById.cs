using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
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
            var country = await _context.Countries.FindAsync(Guid.Parse(request.Id));
            _logger.LogInformation(MHFL.Done("Handle"));
            return new ResponseGetCountryById(_mapper.Map<CountryDTO>(country));
        }
    }
}