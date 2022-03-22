using MediatR;
using Store.BusinessLogic.Common;
using Store.DAL.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Queries.CountryQueries.getCountryById
{
    public static partial class GetCountryById
    {
        public class Handler : IRequestHandler<Query, ResponseBase>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }

            public async Task<ResponseBase> Handle(Query request, CancellationToken cancellationToken)
            {
                var country = await _context.Countries.FindAsync(request.Id);
                return country == null
                    ? new ResponseBase("Country not found", HttpStatusCode.NotFound)
                    : new Response(country.Id, country.Name);
            }
        }
    }
}
