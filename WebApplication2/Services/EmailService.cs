using PaymentTypes.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PaymentTypes.Services
{
    public class EmailService: IEmailService
    {
        SmtpClient _smtpClient;
        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }
       
        public bool SendEmail(MailMessage message)
        {
          _smtpClient.Send(message);
            return true;
            
        }
    }
}
