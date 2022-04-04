using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public record ResponseGetCountryById(CountryDto Country) : ResponseBase;
}