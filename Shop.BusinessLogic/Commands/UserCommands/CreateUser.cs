using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;


namespace Store.BusinessLogic.Commands.UserCommands
{
    public static class CreateUser
    {
        public record Command(string UserName, string Email, string Password, Guid CountryId,
            string PhoneNumber) : IRequest<CQRSResponseBase>;


        public class Validator : IValidationHandler<Command>
        {
            private readonly UserManager<User> _userManager;

            public Validator(UserManager<User> userManager)
            {
                _userManager = userManager;
            }
            public async Task<ValidationResult> Validate(Command request)
            {
                var resultEmail = _userManager.FindByEmailAsync(request.Email);
                if (resultEmail is not null)
                    return ValidationResult.Fail("A user with such an email has already been registered");
                var resultUserName = await _userManager.FindByNameAsync(request.UserName);
                if (resultUserName is not null)
                    return ValidationResult.Fail("A user with such an user has already been registered");
                return ValidationResult.Success;
            }
        }

        public class Handler : IRequestHandler<Command, CQRSResponseBase>
        {
            private readonly IStoreDbContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IPasswordHasher<User> _userHasher;

            public Handler(IStoreDbContext context, UserManager<User> userManager, IPasswordHasher<User> userHasher)
            {
                _context = context;
                _userManager = userManager;
                _userHasher = userHasher;
            }

            public async Task<CQRSResponseBase> Handle(Command request, CancellationToken cancellationToken)
            {
                var country = await _context.Countries.FindAsync(request.CountryId);
                var users = new List<User>();

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

                users.Add(user);
                country.Users = users;
                _context.Countries.Update(country);
                await _userManager.CreateAsync(user);
                await _context.SaveChangesAsync(cancellationToken);

                return new Response(user.Id);
            }

            public record Response(Guid Id) : CQRSResponseBase;
        }
    }
}