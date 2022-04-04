using System;
using Microsoft.AspNetCore.Identity;

namespace Store.DAL.Entities
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public string Expire { get; set; }
    }
}