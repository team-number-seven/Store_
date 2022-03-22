using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public class HandlerAllCountries : IRequestHandler<QueryAllCountries, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerAllCountries> _logger;
        private readonly IMapper _mapper;

        public HandlerAllCountries(IStoreDbContext context, ILogger<HandlerAllCountries> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryAllCountries request, CancellationToken cancellationToken)
        {
            var countries = await _context.Countries.ToListAsync(cancellationToken);
            var response = new ResponseAllCountries(new List<CountryDTO>());
            var task = new Task(() =>
            {
                foreach (var c in countries)
                    response.Countries.Add(_mapper.Map<CountryDTO>(c));
            });

            task.Start();
            _logger.LogInformation($"[{DateTime.Now}]Get countries is successful for {typeof(HandlerAllCountries)}");
            task.Wait(cancellationToken);

            return response;
        }
    }
}