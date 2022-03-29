using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public record QueryGetAllBrands : IRequest<ResponseBase>;
}