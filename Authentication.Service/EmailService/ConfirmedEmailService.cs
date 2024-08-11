using Authentication.Service.ViewModel.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.EmailService
{
    public class ConfirmedEmailService
    {
        private readonly EmailSetting _mailSetting;
        private readonly ILogger<ConfirmedEmailService> _logger;

        public ConfirmedEmailService(IOptions<EmailSetting> mailSetting, ILogger<ConfirmedEmailService> logger)
        {
            _mailSetting = mailSetting.Value;
            _logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

        }
    }
}
