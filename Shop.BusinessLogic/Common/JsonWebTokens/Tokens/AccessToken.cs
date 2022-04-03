using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.JsonWebTokens.Tokens
{
    public record AccessToken(string Token, string Expires);
}
