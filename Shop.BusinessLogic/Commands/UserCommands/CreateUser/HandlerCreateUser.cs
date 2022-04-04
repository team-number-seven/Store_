using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Queries.CountryQueries.GetCountryById;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.CreateUser
{
    public class HandlerCreateUser : IRequestHandler<CommandCreateUser, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerCreateUser> _logger;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher<User> _userHasher;
        private readonly UserManager<User> _userManager;

        public HandlerCreateUser(IStoreDbContext context, UserManager<User> userManager,
            IPasswordHasher<User> userHasher, ILogger<HandlerCreateUser> logger, IMediator mediator)
        {
            _context = context;
            _userManager = userManager;
            _userHasher = userHasher;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseBase> Handle(CommandCreateUser request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FindAsync(request.User.CountryId);
            var users = new List<User>();
            var user = new User
            {
                UserName = request.User.UserName,
                NormalizedUserName = _userManager.NormalizeName(request.User.UserName),
                Email = request.User.Email,
                NormalizedEmail = _userManager.NormalizeEmail(request.User.Email),
                Country = country,
                CountryId = country.Id,
                PhoneNumber = request.User.PhoneNumber,
                CreateDate = DateTime.Now
            };

            user.PasswordHash = _userHasher.HashPassword(user, request.User.Password);

            users.Add(user);
            country.Users = users;
            _context.Countries.Update(country);
            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, "user");
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle", user.Id.ToString()));
            return new ResponseCreateUser(user.Id) {StatusCode = HttpStatusCode.Created};
        }
    }
}