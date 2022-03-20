﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries
{
    public static class GetAllCountries
    {
        public record Query : IRequest<IEnumerable<CQRSResponseBase>>;

        public class Handler: IRequestHandler<Query,IEnumerable<CQRSResponseBase>>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CQRSResponseBase>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = new List<Response>();
                var countries = await _context.Countries.ToListAsync(cancellationToken);
                ParallelLoopResult result = Parallel.ForEach(countries, (c) =>
                {
                    response.Add(new Response(c.Id, c.Name));
                });
                return response;
            }
        }


        public record Response(Guid Id,string Name):CQRSResponseBase;
    }
}
