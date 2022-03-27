using System;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class UserRegistrationDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CountryId { get; set; }
        public string PhoneNumber { get; set; }
    }
}