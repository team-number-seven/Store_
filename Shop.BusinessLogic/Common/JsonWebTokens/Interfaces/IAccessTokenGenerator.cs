using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.JsonWebTokens.Interfaces
{
    public interface IAccessTokenGenerator
    {
        Task<AccessToken> GenerateAccessTokenAsync(User user);
    }
}
