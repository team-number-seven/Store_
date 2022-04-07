using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.Options;
using Store.BusinessLogic.Services.EmailService;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public class HandlerSendConfirmationByEmail : IRequestHandler<QuerySendConfirmationByEmail, ResponseBase>
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly IStoreDbContext _context;
        private readonly MessageConfirmOrDeclineToEmail _optionsUrl;

        public HandlerSendConfirmationByEmail(IEmailService emailService, UserManager<User> userManager,
            IStoreDbContext context, IOptions<MessageConfirmOrDeclineToEmail> optionsUrl)
        {
            _emailService = emailService;
            _userManager = userManager;
            _context = context;
            _optionsUrl = optionsUrl.Value;
        }

        public async Task<ResponseBase> Handle(QuerySendConfirmationByEmail request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var urlConfirm = request.UrlHelper.Action(new UrlActionContext
            {
                Action = _optionsUrl.ActionConfirm, Controller = _optionsUrl.Controller, Host = _optionsUrl.Host,
                Protocol = _optionsUrl.Scheme, Values = new {userId = request.UserId, tokenConfirmation = token}
            });
            var urlDecline = request.UrlHelper.Action(new UrlActionContext
            {
                Action = _optionsUrl.ActionDecline,
                Controller = _optionsUrl.Controller,
                Host = _optionsUrl.Host,
                Protocol = _optionsUrl.Scheme,
                Values = new { userId = request.UserId, tokenConfirmation = token }
            });
            var body = await CreateFormAsync(urlConfirm, urlDecline);

            await _emailService.SendEmailAsync(user.Email, user.UserName, "Email confirmation", body);
            return new ResponseSendConfirmationByEmail(user.Id);
        }

        private async Task<string> CreateFormAsync(string urlConfirm,string urlDecline,string pathForm = null)
        {
            var htmlForm =
                new StringBuilder(await File.ReadAllTextAsync(
                    @"D:\Projects\GitHub\Store\Shop.BusinessLogic\Common\HTML\EmailConfirmation.html"));
            htmlForm.Replace("COFIRMEMAIL", urlConfirm);
            htmlForm.Replace("COFIRMEMAIL", urlConfirm);
            return htmlForm.ToString();

        }


    }
}