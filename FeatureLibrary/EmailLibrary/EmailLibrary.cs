using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FeatureLibrary.EmailLibrary
{
    public class SendEmailModel
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        //cấu hình email
        public string UserName { get; set; }
        public string EmailFrom { get; set; }
        public string Password { get; set; }

        public int Port { get; set; }
        public string Host { get; set; }
        public bool IsEnableSsl { get; set; }
        public bool IsBodyHtml { get; set; }

        public SendEmailModel(string EmailTo, string Subject, string Message, 
            string UserName, string EmailFrom, string Password,
            int Port, string Host, bool IsEnableSsl, bool IsBodyHtml)
        {
            this.EmailTo = EmailTo;
            this.Subject = Subject;
            this.Message = Message;
            this.UserName = UserName;
            this.EmailFrom = EmailFrom;
            this.Password = Password;
            this.Port = Port;
            this.Host = Host;
            this.IsEnableSsl = IsEnableSsl;
            this.IsBodyHtml = IsBodyHtml;
        }
    }
    public class EmailLibrary
    {

        /// <summary>
        /// send email
        /// </summary>
        /// <param name="sendEmailModel"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(SendEmailModel sendEmailModel)
        {
            var smtpClient = new SmtpClient(sendEmailModel.Host)
            {
                Port = sendEmailModel.Port,
                Credentials = new NetworkCredential(sendEmailModel.UserName, sendEmailModel.Password),
                EnableSsl = sendEmailModel.IsEnableSsl,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(sendEmailModel.EmailFrom),
                Subject = sendEmailModel.Subject,
                Body = sendEmailModel.Message,
                IsBodyHtml = sendEmailModel.IsBodyHtml,
            };
            mailMessage.To.Add(sendEmailModel.EmailTo);
            await smtpClient.SendMailAsync(mailMessage);
        }
        /// <summary>
        /// send email
        /// </summary>
        /// <param name="EmailTo"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="UserName"></param>
        /// <param name="EmailFrom"></param>
        /// <param name="Password"></param>
        /// <param name="Port"></param>
        /// <param name="Host"></param>
        /// <param name="IsEnableSsl"></param>
        /// <param name="IsBodyHtml"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string EmailTo, string Subject, string Message,
            string UserName, string EmailFrom, string Password,
            int Port, string Host, bool IsEnableSsl, bool IsBodyHtml)
        {
            var sendEmailModel = new SendEmailModel( EmailTo,  Subject,  Message,
             UserName,  EmailFrom,  Password,
             Port,  Host,  IsEnableSsl,  IsBodyHtml);
            await SendEmailAsync(sendEmailModel);
        }

    }
}
