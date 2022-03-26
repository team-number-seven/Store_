using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public record ResponseGetAllCountries(IList<CountryDTO> Countries) : ResponseBase;
}