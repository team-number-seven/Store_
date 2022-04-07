using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.User
{
    public class UserLoginDto : IMapWith<DAL.Entities.User>
    {
        [FromHeader] public string Email { get; set; }

        [FromHeader] public string Password { get; set; }
    }
}