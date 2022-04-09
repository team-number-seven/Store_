using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Gender;

namespace Store.BusinessLogic.Queries.GenderQueries.GetAllGenders
{
    public record GetAllGendersResponse(IList<GenderDto> Genders) : ResponseBase;
}