using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public record QueryGetItemById([FromBody]Guid Id) : IRequest<ResponseBase>;
}
