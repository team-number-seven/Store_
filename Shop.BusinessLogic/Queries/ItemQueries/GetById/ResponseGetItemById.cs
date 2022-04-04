using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public record ResponseGetItemById(ItemDto Item) : ResponseBase;
}