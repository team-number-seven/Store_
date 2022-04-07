using System.Threading;
using System.Threading.Tasks;
using Store.BusinessLogic.Services.JsonWebTokens.Tokens;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Services.JsonWebTokens.Interfaces
{
    public interface IAccessTokenGenerator
    {
        Task<AccessToken> GenerateAccessTokenAsync(User user, CancellationToken cancellationToken);
    }
}