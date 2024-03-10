using System;
using AuthenticationServer.Models;
using AuthenticationServer.Services.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AuthenticationServer.Services
{
	public class EmailService : IEmailService
	{
        private readonly MailSettings settings;

        public EmailService(IOptions<MailSettings> options)
		{
            settings = options.Value;
		}

        public void SendEmail(MailData data)
        {
           
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(settings.SenderName, settings.SenderEmail));
            email.To.Add(new MailboxAddress(data.EmailToName, data.EmailToId));
            email.Subject = data.EmailToSubject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = EmailTemplate.GetAccountVerificationTemplate().Replace("[Verification_URL]", data.VerificationURL);

            email.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(settings.Server, settings.Port, SecureSocketOptions.StartTls);
                client.Authenticate(settings.SenderEmail, settings.Password);
                client.Send(email);
                client.Disconnect(true);
            }
        }
    }
}

