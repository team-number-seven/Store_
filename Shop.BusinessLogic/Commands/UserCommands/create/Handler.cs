﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Commands.UserCommands.create
{
    public static partial class CreateUser
    {
        public class Handler : IRequestHandler<Command, ResponseBase>
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

            public async Task<ResponseBase> Handle(Command request, CancellationToken cancellationToken)
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
                await _userManager.AddToRoleAsync(user, "user");
                await _context.SaveChangesAsync(cancellationToken);

                return new Response(user.Id);
            }
        }
    }
}
