using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Gender;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public record ResponseGenderById(GenderDto Gender) : ResponseBase;
}