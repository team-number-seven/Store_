using System;
using Microsoft.AspNetCore.Mvc;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class UserRegistrationDTO
    {
        [FromHeader] public string UserName { get; set; }

        [FromHeader] public string Email { get; set; }

        [FromHeader] public string Password { get; set; }

        [FromHeader] public Guid CountryId { get; set; }

        [FromHeader] public string PhoneNumber { get; set; }
    }
}