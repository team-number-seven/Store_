using System;
using Microsoft.AspNetCore.Identity;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class User : IdentityUser, IBaseEntity
    {
        public Guid Id { get; set; }

    }
}