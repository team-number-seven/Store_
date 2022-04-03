﻿using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public record CommandCreateItem(ItemCreateDTO Item) : IRequest<ResponseBase>;
}