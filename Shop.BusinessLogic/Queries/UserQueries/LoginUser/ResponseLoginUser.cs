using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public record ResponseLoginUser(string Token) : ResponseBase;
}
