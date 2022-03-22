using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public record QueryAllCountries : IRequest<ResponseBase>;
}