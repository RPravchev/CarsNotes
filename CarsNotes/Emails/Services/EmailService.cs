using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace CarsNotes.Emails.Services
{/*
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var smtpSettings = _configuration.GetSection("EmailSettings");
            var smtpServer = smtpSettings["SMTPServer"];
            var smtpPort = int.Parse(smtpSettings["SMTPPort"]!);
            var senderEmail = smtpSettings["SenderEmail"];
            var senderName = smtpSettings["SenderName"];
            var senderPassword = smtpSettings["SenderPassword"];

            using var client = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
    */
}
