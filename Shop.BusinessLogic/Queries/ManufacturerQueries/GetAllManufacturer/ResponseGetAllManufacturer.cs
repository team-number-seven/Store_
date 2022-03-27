using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.ManufacturerQueries.GetAllManufacturer
{
    public record ResponseGetAllManufacturer(IList<ManufacturerDTO> Manufacturers) : ResponseBase;
}