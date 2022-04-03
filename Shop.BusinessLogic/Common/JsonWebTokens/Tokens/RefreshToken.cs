using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.JsonWebTokens.Tokens
{
    public record RefreshToken(string Token, string Expires);
}
