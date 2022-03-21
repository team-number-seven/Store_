using Store.BusinessLogic.Common;
using System;

namespace Store.BusinessLogic.Queries.CountryQueries.getCountryBuId
{
    public static partial class GetCountryById
    {
        public record Response(Guid Id, string Name) : ResponseBase;
    }
}
