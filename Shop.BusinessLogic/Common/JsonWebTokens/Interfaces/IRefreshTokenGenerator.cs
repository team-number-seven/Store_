using System.Threading;
using System.Threading.Tasks;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.JsonWebTokens.Interfaces
{
    public interface IRefreshTokenGenerator
    {
        Task<RefreshToken> GenerateRefreshTokenAsync(User user, CancellationToken cancellationToken);
    }
}