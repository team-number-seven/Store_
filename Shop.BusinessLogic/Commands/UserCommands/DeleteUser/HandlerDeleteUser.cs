using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public class HandlerDeleteUser:IRequestHandler<CommandDeleteUser,ResponseBase>
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HandlerDeleteUser> _logger;

        public HandlerDeleteUser(UserManager<User> userManager,ILogger<HandlerDeleteUser> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<ResponseBase> Handle(CommandDeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            await _userManager.DeleteAsync(user);
            _logger.LogInformation($"User successfully deleted id[{user.Id}]");
            return new ResponseDeleteUser(request.UserId);
        }
    }
}
