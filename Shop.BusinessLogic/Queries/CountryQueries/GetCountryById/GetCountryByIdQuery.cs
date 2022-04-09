using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public record GetCountryByIdQuery(Guid Id) : IRequest<ResponseBase>;
}