using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem
{
    public record ResponseGetAllAgeTypeItem(IList<AgeTypeItemDTO> Types):ResponseBase;
}
