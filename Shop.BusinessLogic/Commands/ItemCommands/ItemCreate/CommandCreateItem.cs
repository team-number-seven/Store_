﻿using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public record CommandCreateItem(ItemCreateDto Item) : IRequest<ResponseBase>;
}