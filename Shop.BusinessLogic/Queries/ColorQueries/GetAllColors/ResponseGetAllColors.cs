using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.ColorQueries.GetAllColors
{
    public record ResponseGetAllColors(IList<ColorDTO> Colors) : ResponseBase;
}
