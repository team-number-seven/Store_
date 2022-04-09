using System.Collections.Generic;
using System.Linq;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Size;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Queries.SizeQueries.GetAllSizes
{
    public record GetAllSizesResponse(IEnumerable<IGrouping<string, SizeDto>> dto) : ResponseBase;
}