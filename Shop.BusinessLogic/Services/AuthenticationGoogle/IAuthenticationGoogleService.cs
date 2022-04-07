using System.Threading.Tasks;
using MailKit.Security;

namespace Store.BusinessLogic.Services.AuthGoogle
{
    public interface IAuthenticationGoogleService
    {
        public Task<SaslMechanismOAuth2> AuthorizationAsync();
    }
}