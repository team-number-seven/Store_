using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public record QueryGetItemById(Guid Id) : IRequest<ResponseBase>;
}