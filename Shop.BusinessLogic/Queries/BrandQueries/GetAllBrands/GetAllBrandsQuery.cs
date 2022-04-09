using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public record GetAllBrandsQuery : IRequest<ResponseBase>;
}