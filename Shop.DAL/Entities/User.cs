using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public DateTime CreateDate { get; set; }

        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }

        public virtual IEnumerable<BagItem> BagItems { get; set; }

        public virtual IEnumerable<Item> FavoriteItems { get; set; }
    }
}