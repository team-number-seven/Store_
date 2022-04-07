using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using MailKit.Security;
using Microsoft.Extensions.Options;

namespace Store.BusinessLogic.Services.AuthGoogle
{
    public class AuthGoogleService:IAuthGoogleService
    {
        private readonly GoogleConfiguration _googleOptions;

        public AuthGoogleService(IOptions<GoogleConfiguration> googleOptions)
        {
            _googleOptions = googleOptions.Value;
        }
        public async Task<SaslMechanismOAuth2> AuthorizationAsync()
        {
            var secrets = new ClientSecrets
            {
                ClientId = _googleOptions.ClientId,
                ClientSecret = _googleOptions.ClientSecret
            };
            var tokenResponse = new TokenResponse
            {
                RefreshToken = _googleOptions.RefreshToken
            };
            var userCredential = new UserCredential(new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = secrets
            }), _googleOptions.UserId, tokenResponse);
            await userCredential.GetAccessTokenForRequestAsync();

            return new SaslMechanismOAuth2(userCredential.UserId, userCredential.Token.AccessToken);

        }
    }
}
