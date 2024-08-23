using Authentication.User.Service.ViewModels.Settings;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.EmailService
{
    public class SendMailService : IEmailService
    {
        private readonly EmailSetting _mailSetting;
        private readonly ILogger<SendMailService> _logger;

        public SendMailService(IOptions<EmailSetting> mailSetting, ILogger<SendMailService> logger)
        {
            _mailSetting = mailSetting.Value;
            _logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(_mailSetting.SenderName, _mailSetting.SenderEmail);
            message.From.Add(new MailboxAddress(_mailSetting.SenderName, _mailSetting.SenderEmail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(_mailSetting.SmtpServer, _mailSetting.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSetting.SenderEmail, _mailSetting.Password);
                await smtp.SendAsync(message);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailsavefile);

                _logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                _logger.LogError(ex.Message);
            }

            smtp.Disconnect(true);

            _logger.LogInformation("send mail to: " + email);
        }
    }
}
