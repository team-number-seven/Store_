using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using Store.DAL.Interfaces;


namespace Store.BusinessLogic.Commands.UserCommands
{
    public static class CreateUser
    {
        public record Command(string UserName, string Email, string Password, string Country,
            string PhoneNumber) : IRequest<Guid>;

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IStoreDbContext _context;
            private readonly IUserStore<User> _userManager;

            public Handler(IStoreDbContext context, IUserStore<User> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                //In the future, this code will be replaced with query
                var Country =
                    await _context.Countries.FirstOrDefaultAsync(c => c.Name == request.Country, cancellationToken);
                //
                var user = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    PasswordHash = request.Password,
                    Country = Country,
                    CountryId = Country.Id,
                    PhoneNumber = request.PhoneNumber,
                    NormalizedUserName = request.UserName,
                    CreateDate = DateTime.Now
                };

                //In the future, this code will be replaced with query
                var users = new List<User>();
                users.Add(user);
                Country.Users = users;
                _context.Countries.Update(Country);
                //
                await _userManager.CreateAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return user.Id;
            }
        }
    }
}