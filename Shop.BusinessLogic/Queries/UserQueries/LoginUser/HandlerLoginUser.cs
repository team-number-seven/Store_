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
using Store.BusinessLogic.Common.Interfaces;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class HandlerLoginUser:IRequestHandler<QueryLoginUser,ResponseBase>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStoreDbContext _context;
        private readonly IJWTService _jwtService;
        private readonly ILogger<HandlerLoginUser> _logger;

        public HandlerLoginUser(UserManager<User> userManager,IStoreDbContext context,IJWTService jwtService,ILogger<HandlerLoginUser> logger)
        {
            _userManager = userManager;
            _context = context;
            _jwtService = jwtService;
            _logger = logger;
        }
        public async Task<ResponseBase> Handle(QueryLoginUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            await _context.Entry(user).Reference(c => c.Country).LoadAsync(cancellationToken);
            _logger.LogInformation($"[{DateTime.Now}] User is successfully logged in");
            return new ResponseLoginUser(_jwtService.GenerateJwtToken(user));
        }
    }
}
