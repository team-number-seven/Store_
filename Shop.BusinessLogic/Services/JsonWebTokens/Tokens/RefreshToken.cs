namespace Store.BusinessLogic.Services.JsonWebTokens.Tokens
{
    public record RefreshToken(string Token, string Expires, string Provider, string Purpose);

    public record RefreshTokenResponse(string Token, string Expires);
}