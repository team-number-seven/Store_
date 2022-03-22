using System.Collections.Generic;
using Store.BusinessLogic.Common;
using static Store.BusinessLogic.Common.DTOS.EntitiesDTOS;

namespace Store.BusinessLogic.Queries.GenderQueries.getAllGenders
{
    public static partial class GetAllGenders
    {
        public record Response(IList<GenderDTO> Genders):ResponseBase;
    }
}
