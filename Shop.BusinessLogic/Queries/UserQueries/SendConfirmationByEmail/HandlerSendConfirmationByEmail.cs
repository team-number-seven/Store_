using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
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

        public HandlerSendConfirmationByEmail(IEmailService emailService, UserManager<User> userManager,IStoreDbContext context)
        {
            _emailService = emailService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<ResponseBase> Handle(QuerySendConfirmationByEmail request,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var uriCreate = $"https://localhost:5001/Store/Home/VerifyEmail?userId={user.Id}&code={token}";
            string myString =
                await File.ReadAllTextAsync(
                    @"D:\Projects\GitHub\Store\Shop.BusinessLogic\Common\HTML\EmailConfirmation.html", cancellationToken);
            var body = myString.Replace("CONFRIMQUERY", uriCreate);
            await _emailService.SendEmailAsync("pavell.urusov8@gmail.com", user.UserName, "Email confirmation", body);

            return new ResponseSendConfirmationByEmail(user.Id);
        }
    }
}