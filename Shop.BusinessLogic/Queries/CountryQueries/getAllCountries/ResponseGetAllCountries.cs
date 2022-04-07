using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Country;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public record ResponseGetAllCountries(IList<CountryDto> Countries) : ResponseBase;
}