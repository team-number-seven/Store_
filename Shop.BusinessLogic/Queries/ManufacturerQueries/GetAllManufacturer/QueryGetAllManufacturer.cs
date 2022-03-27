using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ManufacturerQueries.GetAllManufacturer
{
    public record QueryGetAllManufacturer : IRequest<ResponseBase>;
}