using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.CountryQueries
{
    public static class GetCountryById
    {
        public record Query(Guid Id) : IRequest<CQRSResponseBase>;

        public class Handler : IRequestHandler<Query, CQRSResponseBase>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }

            public async Task<CQRSResponseBase> Handle(Query request, CancellationToken cancellationToken)
            {
                var country = await _context.Countries.FindAsync(request.Id);
                return country == null
                    ? new CQRSResponseBase("Country not found", HttpStatusCode.NotFound)
                    : new Response(country.Id, country.Name);
            }
        }

        public record Response(Guid Id, string Name) : CQRSResponseBase;
    }
}