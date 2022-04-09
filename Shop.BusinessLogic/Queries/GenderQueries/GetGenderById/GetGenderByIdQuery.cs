using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public record GetGenderByIdQuery(Guid Id) : IRequest<ResponseBase>;
}