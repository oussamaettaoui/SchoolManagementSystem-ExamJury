using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Dtos.EmailDtos;

namespace SchoolManagementSystem.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmailAsync(EmailDto emailDto)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(emailDto.To));
            email.Subject = emailDto.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailDto.Body};
            //
            var username = _config.GetValue<string>("EmailUserName");
            var password = _config.GetValue<string>("EmailPassword");
            //
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587,SecureSocketOptions.StartTls);
            smtp.Authenticate(username,password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
