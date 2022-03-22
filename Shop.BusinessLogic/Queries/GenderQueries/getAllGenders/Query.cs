using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.GenderQueries.getAllGenders
{
    public static partial class GetAllGenders
    {
        public record Query() : IRequest<ResponseBase>;
    }
}
