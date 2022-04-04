using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByFilter
{
    public record ResponseItemFilter(IList<ItemQueryResponseDTO> Items) : ResponseBase;
}
