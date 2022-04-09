using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Color;

namespace Store.BusinessLogic.Queries.ColorQueries.GetAllColors
{
    public record GetAllColorsResponse(IList<ColorDto> Colors) : ResponseBase;
}