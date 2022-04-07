using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Options;
using Store.BusinessLogic.Services.AuthGoogle;
using Store.BusinessLogic.Services.EmailService;

namespace Store.BusinessLogic.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IAuthenticationGoogleService _authenticationGoogle;
        private readonly EmailConfigure _emailConfig;
        private readonly ILogger<EmailService> _logger;


        public EmailService(IOptions<EmailConfigure> emailOptions, IAuthenticationGoogleService authenticationGoogle,
            ILogger<EmailService> logger)
        {
            _authenticationGoogle = authenticationGoogle;
            _logger = logger;
            _emailConfig = emailOptions.Value;
        }

        public async Task SendEmailAsync(string email, string name, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(_emailConfig.FromName, _emailConfig.FromAddress));
                emailMessage.To.Add(new MailboxAddress(name, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) {Text = message};
                var oauth2 = await _authenticationGoogle.AuthorizationAsync();
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailConfig.MailServerAddress, _emailConfig.MailServerPort,
                        _emailConfig.SecureSocket);
                    await client.AuthenticateAsync(oauth2);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }

                _logger.LogInformation(LoggerMessages.DoneMessage(nameof(SendEmailAsync)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}