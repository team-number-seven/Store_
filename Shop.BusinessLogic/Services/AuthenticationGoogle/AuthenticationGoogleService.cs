using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Options;
using Store.BusinessLogic.Services.AuthGoogle;

namespace Store.BusinessLogic.Services.AuthenticationGoogle
{
    public class AuthenticationGoogleService : IAuthenticationGoogleService
    {
        private readonly GoogleAuthenticationConfiguration _googleAuthenticationOptions;
        private readonly ILogger<AuthenticationGoogleService> _logger;

        public AuthenticationGoogleService(IOptions<GoogleAuthenticationConfiguration> googleOptions,
            ILogger<AuthenticationGoogleService> logger)
        {
            _logger = logger;
            _googleAuthenticationOptions = googleOptions.Value;
        }

        public async Task<SaslMechanismOAuth2> AuthorizationAsync()
        {
            var secrets = new ClientSecrets
            {
                ClientId = _googleAuthenticationOptions.ClientId,
                ClientSecret = _googleAuthenticationOptions.ClientSecret
            };
            var tokenResponse = new TokenResponse
            {
                RefreshToken = _googleAuthenticationOptions.RefreshToken
            };
            var userCredential = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = secrets
                }), _googleAuthenticationOptions.UserId, tokenResponse);
            await userCredential.GetAccessTokenForRequestAsync();
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(AuthorizationAsync)));

            return new SaslMechanismOAuth2(userCredential.UserId, userCredential.Token.AccessToken);
        }
    }
}