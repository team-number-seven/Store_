using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class UserRole:IdentityUserRole<Guid>
    {
    }
}
