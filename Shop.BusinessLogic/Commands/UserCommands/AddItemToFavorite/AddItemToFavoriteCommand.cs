using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.FavoriteItem;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToFavorite
{
    public record AddItemToFavoriteCommand(AddFavoriteItemDto FavoriteItem) : IRequest<ResponseBase>;
}
