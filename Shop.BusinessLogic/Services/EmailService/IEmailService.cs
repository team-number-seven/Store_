using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Store.BusinessLogic.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string name, string subject, string message);
    }
}