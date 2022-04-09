using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public record GetAllCountriesQuery : IRequest<ResponseBase>;
}