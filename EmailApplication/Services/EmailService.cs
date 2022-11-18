using EmailApplication.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmailApplication.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<string> SendEmailAsync(EmailRequest emailRequest)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_emailSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(emailRequest.ToEmail));
            message.Subject = emailRequest.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = emailRequest.Body };

            var client = new SmtpClient();

            try
            {
                Log.Information($"SendEmail - Details\nSender: {_emailSettings.SenderEmail}\nRecipient: {emailRequest.ToEmail}\nSubject: {emailRequest.Subject}\nBody: {emailRequest.Body}\nDateTime: {DateTime.Now}");

                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Successful";
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                client.Dispose();
            }

        }
    }
}
