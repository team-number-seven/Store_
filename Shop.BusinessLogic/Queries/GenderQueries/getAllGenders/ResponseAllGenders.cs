using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.GenderQueries.GetAllGenders
{
    public record ResponseAllGenders(IList<GenderDTO> Genders) : ResponseBase;
}