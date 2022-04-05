using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public record ResponseGenderById(GenderDto Gender) : ResponseBase;
}