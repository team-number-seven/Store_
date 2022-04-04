using System;
using System.Collections.Generic;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.ImageCommand
{
    public record CreateImageResponse(IList<Guid> Guids) : ResponseBase;
}