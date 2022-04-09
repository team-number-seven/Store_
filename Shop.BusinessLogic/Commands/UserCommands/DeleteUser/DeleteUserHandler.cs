using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResponseBase>
    {
        private readonly ILogger<DeleteUserHandler> _logger;
        private readonly UserManager<User> _userManager;

        public DeleteUserHandler(UserManager<User> userManager, ILogger<DeleteUserHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            await _userManager.DeleteAsync(user);
            _logger.LogInformation($"User successfully deleted id[{user.Id}]");
            return new DeleteUserResponse(request.UserId);
        }
    }
}