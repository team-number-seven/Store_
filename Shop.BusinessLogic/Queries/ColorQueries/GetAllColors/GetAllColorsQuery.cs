using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ColorQueries.GetAllColors
{
    public record GetAllColorsQuery : IRequest<ResponseBase>;
}