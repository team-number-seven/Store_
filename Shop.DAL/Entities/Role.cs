using System;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Role : IdentityRole<Guid>
    {
    }
}