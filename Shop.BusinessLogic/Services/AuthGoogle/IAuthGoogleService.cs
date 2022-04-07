using System.Threading.Tasks;
using MailKit.Security;

namespace Store.BusinessLogic.Services.AuthGoogle
{
    public interface IAuthGoogleService
    {
        public Task<SaslMechanismOAuth2> AuthorizationAsync();
    }
}
