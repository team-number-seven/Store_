using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToFavorite
{
    public record AddItemToFavoriteResponse(Guid Id) : ResponseBase;
}
