using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.GenderQueries.GetAllGenders
{
    public record QueryAllGenders : IRequest<ResponseBase>;
}