using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.IO.Core.Identity.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient smtpC = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("atvmsoft@gmail.com", "Atvm@@2018"),
                EnableSsl = true
            };

            MailMessage mMessage = new MailMessage()
            {
                From = new MailAddress("noreply@advapp.com.br", "Adv - App"),
                IsBodyHtml = true
            };

            mMessage.Body = message;
            mMessage.Subject = subject;
            mMessage.To.Add(email);
            smtpC.Send(mMessage);

            return Task.CompletedTask;
        }
    }
}
