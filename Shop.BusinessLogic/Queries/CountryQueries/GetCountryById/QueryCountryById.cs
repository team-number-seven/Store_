using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public record QueryCountryById(Guid Id) : IRequest<ResponseBase>;
}