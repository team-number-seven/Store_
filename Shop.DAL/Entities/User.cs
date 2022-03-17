using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class User : IdentityUser, IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }

        public IEnumerable<Item> BagItems { get; set; }

        public IEnumerable<Item> FavoriteItems { get; set; }

    }
}