using System.Net;
using System.Net.Mail;

namespace FreelanceCRM.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient(_config["EmailSettings:Host"])
            {
                Port = int.Parse(_config["EmailSettings:Port"]),
                Credentials = new NetworkCredential(_config["EmailSettings:Username"], _config["EmailSettings:Password"]),
                EnableSsl = true
            }
            ;
            var mail = new MailMessage(_config["EmailSettings:Username"], to, subject, body);
            mail.IsBodyHtml = true; // for HTML email content
            smtpClient.Send(mail);


     
        }


    }
}
