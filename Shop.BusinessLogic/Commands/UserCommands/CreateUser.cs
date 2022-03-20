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
        public record Command(string UserName, string Email, string Password, Guid CountryId,
            string PhoneNumber) : IRequest<Guid>;

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IStoreDbContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IPasswordHasher<User> _userHasher;

            public Handler(IStoreDbContext context, UserManager<User> userManager,IPasswordHasher<User> userHasher)
            {
                _context = context;
                _userManager = userManager;
                _userHasher = userHasher;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                //In the future, this code will be replaced with query
                var country = await _context.Countries.FindAsync(request.CountryId);

                //
                var user = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Country = country,
                    CountryId = country.Id,
                    NormalizedEmail = _userManager.NormalizeEmail(request.Email),
                    PhoneNumber = request.PhoneNumber,
                    NormalizedUserName = _userManager.NormalizeName(request.UserName),
                    CreateDate = DateTime.Now
                };
                user.PasswordHash = _userHasher.HashPassword(user, request.Password);

                //In the future, this code will be replaced with query
                var users = new List<User>();
                users.Add(user);
                country.Users = users;
                _context.Countries.Update(country);
                //
                await _userManager.CreateAsync(user);
                await _context.SaveChangesAsync(cancellationToken);
                return user.Id;
            }
        }
    }
}