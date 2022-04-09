using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Gender;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public record GetGenderByIdResponse(GenderDto Gender) : ResponseBase;
}