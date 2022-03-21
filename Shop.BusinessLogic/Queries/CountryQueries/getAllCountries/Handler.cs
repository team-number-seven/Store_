using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Queries.CountryQueries.getAllCountries
{
    public static partial class GetAllCountries
    {
        public class Handler : IRequestHandler<Query, IEnumerable<ResponseBase>>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ResponseBase>> Handle(Query request, CancellationToken cancellationToken)
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
    }
}
