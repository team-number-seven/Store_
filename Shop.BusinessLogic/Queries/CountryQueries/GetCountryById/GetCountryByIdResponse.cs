using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Country;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public record GetCountryByIdResponse(CountryDto Country) : ResponseBase;
}