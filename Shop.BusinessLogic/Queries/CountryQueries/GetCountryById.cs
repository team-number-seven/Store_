using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries
{
    public static class GetCountryById
    {
        public record Query(Guid Id) : IRequest<Response>;

        public class Handler:IRequestHandler<Query,Response>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var country = await _context.Countries.FindAsync(request.Id);
                return country == null ? null : new Response(country.Id,country.Name);
            }
        }
        
        public record Response(Guid Id,string Name);
    }
}
