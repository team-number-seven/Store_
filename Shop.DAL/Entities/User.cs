using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class User : IdentityUser<Guid>,IBaseEntity
    {
        public DateTime CreateDate { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }

        public IEnumerable<Item> BagItems { get; set; }

        public IEnumerable<Item> FavoriteItems { get; set; }

    }
}