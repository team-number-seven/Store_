using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public record QueryGenderById(Guid Id) : IRequest<ResponseBase>;
}