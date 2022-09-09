using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;



namespace Fintech.Application.Services
{

    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }
    public class EmailService : IEmailService
    {

        public void Send(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("dianaduque11@gmail.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = body };


            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("taylor.daniel@ethereal.email", "rz3shnPPm8JJTugyPJ");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
