using MediatR;
using Store.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Queries.CountryQueries.getAllCountries
{
    public static partial class GetAllCountries
    {
        public record Query : IRequest<IEnumerable<ResponseBase>>;
    }
}
