using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Options;
using Store.BusinessLogic.Services.EmailService;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public class HandlerSendConfirmationByEmail : IRequestHandler<QuerySendConfirmationByEmail, ResponseBase>
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<HandlerSendConfirmationByEmail> _logger;
        private readonly ConfirmAndDeclineUrlConfiguration _optionsUrlConfiguration;
        private readonly UserManager<User> _userManager;

        public HandlerSendConfirmationByEmail(IEmailService emailService, UserManager<User> userManager,
            IStoreDbContext context, IOptions<ConfirmAndDeclineUrlConfiguration> optionsUrl,
            ILogger<HandlerSendConfirmationByEmail> logger)
        {
            _emailService = emailService;
            _userManager = userManager;
            _logger = logger;
            _optionsUrlConfiguration = optionsUrl.Value;
        }

        public async Task<ResponseBase> Handle(QuerySendConfirmationByEmail request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var urlConfirm = request.UrlHelper.Action(new UrlActionContext
            {
                Action = _optionsUrlConfiguration.ActionConfirm, Controller = _optionsUrlConfiguration.Controller,
                Host = _optionsUrlConfiguration.Host,
                Protocol = _optionsUrlConfiguration.Scheme,
                Values = new {userId = request.UserId, tokenConfirmation = token}
            });
            var urlDecline = request.UrlHelper.Action(new UrlActionContext
            {
                Action = _optionsUrlConfiguration.ActionDecline,
                Controller = _optionsUrlConfiguration.Controller,
                Host = _optionsUrlConfiguration.Host,
                Protocol = _optionsUrlConfiguration.Scheme,
                Values = new {userId = request.UserId, tokenConfirmation = token}
            });
            var body = await CreateFormAsync(urlConfirm, urlDecline);

            await _emailService.SendEmailAsync(user.Email, user.UserName, "Email confirmation", body);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle), user.Id.ToString()));

            return new ResponseSendConfirmationByEmail(user.Id);
        }

        private async Task<string> CreateFormAsync(string urlConfirm, string urlDecline, string pathForm = null)
        {
            // TODO Magic words
            var htmlForm =
                new StringBuilder(await File.ReadAllTextAsync(
                    @"D:\Repositories\Store\Shop.BusinessLogic\Common\HTML\EmailConfirmation.html"));
            htmlForm.Replace("COFIRMEMAIL", urlConfirm);
            htmlForm.Replace("COFIRMEMAIL", urlConfirm);

            return htmlForm.ToString();
        }
    }
}