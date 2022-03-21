using Store.BusinessLogic.Common;
using System.Collections.Generic;
using Store.BusinessLogic.Common.DTOS;

namespace Store.BusinessLogic.Queries.CountryQueries.getAllCountries
{
    public static partial class GetAllCountries
    {
        public record Response(IList<EntitiesDTOS.CountryDTO> Countries) : ResponseBase;
    }
}
