using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string name, string subject, string message);
    }
}