using Store.BusinessLogic.Common;
using System;

namespace Store.BusinessLogic.Queries.CountryQueries.getAllCountries
{
    public static partial class GetAllCountries
    {
        public record Response(Guid Id, string Name) : ResponseBase;
    }
}
