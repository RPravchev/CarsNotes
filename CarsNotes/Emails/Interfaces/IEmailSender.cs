using System.Threading.Tasks;

namespace CarsNotes.Emails.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
