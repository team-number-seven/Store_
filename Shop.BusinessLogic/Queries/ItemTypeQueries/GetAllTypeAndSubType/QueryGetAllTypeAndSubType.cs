using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypeAndSubType
{
    public record QueryGetAllTypeAndSubType : IRequest<ResponseBase>;
}
