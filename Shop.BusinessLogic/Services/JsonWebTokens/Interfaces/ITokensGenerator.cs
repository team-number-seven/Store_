namespace Store.BusinessLogic.Services.JsonWebTokens.Interfaces
{
    public interface ITokensGenerator : IAccessTokenGenerator, IRefreshTokenGenerator
    {
    }
}