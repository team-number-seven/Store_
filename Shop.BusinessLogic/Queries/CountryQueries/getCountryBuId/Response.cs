using Store.BusinessLogic.Common;
using System;

namespace Store.BusinessLogic.Queries.CountryQueries.getCountryById
{
    public static partial class GetCountryById
    {
        public record Response(Guid Id, string Name) : ResponseBase;
    }
}
