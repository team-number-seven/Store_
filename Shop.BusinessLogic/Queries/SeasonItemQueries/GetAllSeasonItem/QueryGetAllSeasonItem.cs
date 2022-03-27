using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasonItem
{
    public record QueryGetAllSeasonItem : IRequest<ResponseBase>;
}
