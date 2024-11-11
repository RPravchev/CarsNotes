using Newtonsoft.Json.Linq;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Diagnostics;

namespace CarsNotes.Emails.Services
{
    public class EmailSender
    {
        public static void SendEmail(string senderEmail, string senderName, string receiverEmail, string receiverName, string subject, string message)
        {
            var apiInstance = new TransactionalEmailsApi();
            SendSmtpEmailSender sender = new SendSmtpEmailSender(senderName, senderEmail);
            SendSmtpEmailTo receiver1 = new SendSmtpEmailTo(receiverEmail, receiverName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(receiver1);

            string HtmlContent = null; //"<html><body><h1>This is my first transactional email {{params.parameter}}</h1></body></html>";
            string TextContent = message;
          
            try
            {
                var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, HtmlContent, TextContent, subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                //Debug.WriteLine(result.ToJson());
                Console.WriteLine("Brevo Response: " + result.ToJson());
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);
                Console.WriteLine("We have an exception: " + e.Message);
                //Console.ReadLine();
            }
        }
    }
}
