using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class UserLoginDTO : IMapWith<User>
    {
        [FromHeader] public string Email { get; set; }

        [FromHeader] public string Password { get; set; }
    }
}