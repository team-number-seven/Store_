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
    public class HandlerCountryById : IRequestHandler<QueryCountryById, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerCountryById> _logger;
        private readonly IMapper _mapper;

        public HandlerCountryById(IStoreDbContext context, IMapper mapper, ILogger<HandlerCountryById> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryCountryById request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FindAsync(request.Id);

            if (country is null)
            {
                _logger.LogInformation($"[{DateTime.Now}] Gender by id not found");
                return new ResponseBase("Country not found", HttpStatusCode.NotFound);
            }

            _logger.LogInformation($"[{DateTime.Now}] Country by id found successfully");
            return new ResponseCountryById(_mapper.Map<CountryDTO>(country));
        }
    }
}