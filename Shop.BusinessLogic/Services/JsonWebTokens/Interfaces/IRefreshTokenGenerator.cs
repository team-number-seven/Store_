using System.Threading;
using System.Threading.Tasks;
using Store.BusinessLogic.Services.JsonWebTokens.Tokens;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Services.JsonWebTokens.Interfaces
{
    public interface IRefreshTokenGenerator
    {
        Task<RefreshToken> GenerateRefreshTokenAsync(User user, CancellationToken cancellationToken);
    }
}