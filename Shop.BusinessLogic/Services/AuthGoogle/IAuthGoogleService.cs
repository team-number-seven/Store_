using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using MailKit.Security;

namespace Store.BusinessLogic.Services.AuthGoogle
{
    public interface IAuthGoogleService
    {
        public Task<SaslMechanismOAuth2> AuthorizationAsync();
    }
}
