﻿using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static Store.BusinessLogic.Common.DTOS.EntitiesDTOS;

namespace Store.BusinessLogic.Queries.CountryQueries.getAllCountries
{
    public static partial class GetAllCountries
    {
        public class Handler : IRequestHandler<Query, ResponseBase>
        {
            private readonly IStoreDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IStoreDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<ResponseBase> Handle(Query request, CancellationToken cancellationToken)
            {
                var countries = await _context.Countries.ToListAsync(cancellationToken);
                var response = new Response(new List<CountryDTO>());

                Parallel.ForEach(countries, c => response.Countries.Add(new CountryDTO(c.Id, c.Name)));

                _logger.LogInformation($"[{DateTime.Now}]Get countries is successful for {typeof(Handler)}");

                return response;
            }
        }
    }
}