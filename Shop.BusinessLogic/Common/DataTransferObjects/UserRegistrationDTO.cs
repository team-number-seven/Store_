using Microsoft.AspNetCore.Mvc;
using System;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class UserRegistrationDTO
    {
        [FromHeader]
        public string UserName { get; set; }
        [FromHeader]

        public string Email { get; set; }
        [FromHeader]

        public string Password { get; set; }
        [FromHeader]

        public string CountryId { get; set; }
        [FromHeader]

        public string PhoneNumber { get; set; }
    }
}